using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Web.Server
{
    public class CheckInSocketServer
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<CheckInSocketServer> _logger;
        private readonly TcpListener _listener;

        public CheckInSocketServer(IServiceScopeFactory scopeFactory,
                                   ILogger<CheckInSocketServer> logger,
                                   int port = 9000)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
            _listener = new TcpListener(IPAddress.Any, port);
            _listener.Start();
            _logger.LogInformation($"Socket server listening on port {port}");
        }

        public async Task StartAsync(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                // Хүлээгдэж буй клиент холболтыг авах
                var client = await _listener.AcceptTcpClientAsync(ct);
                _ = HandleClientAsync(client, ct);
            }
        }

        private async Task HandleClientAsync(TcpClient client, CancellationToken ct)
        {
            using (client)
            using (var stream = client.GetStream())
            {
                try
                {
                    while (!ct.IsCancellationRequested)
                    {
                        // Мессеж унших
                        var message = await ReceiveMessageAsync(stream, ct);
                        if (message == null) break;  // Клиент холбогдолтоо тасалсан

                        // Шинэ DI scope үүсгэж, процессороо дуудаж
                        using var scope = _scopeFactory.CreateScope();
                        var processor = scope.ServiceProvider
                                             .GetRequiredService<SeatCommandProcessor>();
                        var response = await processor.ProcessAsync(message);

                        // Үр дүнг буцаах
                        await SendMessageAsync(stream, response, ct);
                    }
                }
                catch (OperationCanceledException) { }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error handling socket client");
                }
            }
        }

        // 1) Stream-аас '\n' хүртэлх JSON текстийг уншиж буцаана
        private async Task<string?> ReceiveMessageAsync(NetworkStream stream, CancellationToken ct)
        {
            var sb = new StringBuilder();
            var buffer = new byte[1024];

            while (!ct.IsCancellationRequested)
            {
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, ct);
                if (bytesRead == 0)
                    return null; // холболт тасарсан

                sb.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));

                // Newline-өөр төгсгөл мэдэгдэж байвал уншиж дуусав
                if (sb.Length > 0 && sb[^1] == '\n')
                    break;
            }

            // Newline болон carriage return-ыг тайрч үлдсэнийг буцаана
            return sb.ToString().TrimEnd('\r', '\n');
        }

        // 2) Stream рүү JSON хариуг '\n'-тэйгээр илгээдэг
        private async Task SendMessageAsync(NetworkStream stream, string message, CancellationToken ct)
        {
            var bytes = Encoding.UTF8.GetBytes(message + "\n");
            await stream.WriteAsync(bytes, 0, bytes.Length, ct);
            await stream.FlushAsync(ct);
        }
    }
}
