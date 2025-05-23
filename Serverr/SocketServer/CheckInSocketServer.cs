using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Serverr.SocketServer
{
    public class CheckInSocketServer
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<CheckInSocketServer> _logger;
        private readonly TcpListener _listener;
        private bool _isRunning = false;

        public CheckInSocketServer(IServiceScopeFactory scopeFactory,
                                   ILogger<CheckInSocketServer> logger,
                                   int port = 9000)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
            _listener = new TcpListener(IPAddress.Any, port);
        }

        public async Task StartAsync(CancellationToken ct)
        {
            _listener.Start();
            _isRunning = true;
            _logger.LogInformation("✅ Socket server started on port {Port}", ((IPEndPoint)_listener.LocalEndpoint).Port);

            while (!ct.IsCancellationRequested)
            {
                try
                {
                    var client = await _listener.AcceptTcpClientAsync(ct);
                    _logger.LogInformation("🔌 Client connected: {Client}", client.Client.RemoteEndPoint);
                    _ = HandleClientAsync(client, ct);
                }
                catch (ObjectDisposedException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "⚠️ Error accepting client connection");
                }
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
                        var message = await ReceiveMessageAsync(stream, ct);
                        if (message == null) break;

                        using var scope = _scopeFactory.CreateScope();
                        var processor = scope.ServiceProvider.GetService<SeatCommandProcessor>();
                        if (processor == null)
                        {
                            _logger.LogWarning("⚠️ SeatCommandProcessor not resolved.");
                            break;
                        }

                        var response = await processor.ProcessAsync(message);
                        await SendMessageAsync(stream, response, ct);
                    }
                }
                catch (OperationCanceledException) { }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "❌ Error handling socket client");
                }
                finally
                {
                    _logger.LogInformation("🔌 Client disconnected: {Client}", client.Client.RemoteEndPoint);
                }
            }
        }

        private async Task<string?> ReceiveMessageAsync(NetworkStream stream, CancellationToken ct)
        {
            var sb = new StringBuilder();
            var buffer = new byte[1024];

            while (!ct.IsCancellationRequested)
            {
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, ct);
                if (bytesRead == 0) return null;

                sb.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                if (sb[^1] == '\n') break;
            }

            return sb.ToString().TrimEnd('\r', '\n');
        }

        private async Task SendMessageAsync(NetworkStream stream, string message, CancellationToken ct)
        {
            var bytes = Encoding.UTF8.GetBytes(message + "\n");
            await stream.WriteAsync(bytes, 0, bytes.Length, ct);
            await stream.FlushAsync(ct);
        }

        public void Stop()
        {
            if (_isRunning)
            {
                _listener.Stop();
                _isRunning = false;
                _logger.LogInformation("🛑 Socket server stopped");
            }
        }
    }
}