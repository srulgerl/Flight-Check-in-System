// Server/SocketServer/CheckInSocketServer.cs
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server.SocketServer
{
    public class CheckInSocketServer
    {
        private readonly TcpListener _listener;
        private readonly List<ClientHandler> _clients = new();
        private readonly SeatCommandProcessor _processor;

        public CheckInSocketServer(int port)
        {
            _listener = new TcpListener(IPAddress.Any, port);
        }

        public CheckInSocketServer(SeatCommandProcessor processor)
        {
            _processor = processor;
            _listener = new TcpListener(IPAddress.Any, 9000);
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _listener.Start();

            while (!cancellationToken.IsCancellationRequested)
            {
                var tcpClient = await _listener.AcceptTcpClientAsync();
                var handler = new ClientHandler(tcpClient, BroadcastMessageAsync, _processor);
                _clients.Add(handler);
                _ = handler.ProcessAsync();
            }
        }

        private async Task BroadcastMessageAsync(string message)
        {
            var tasks = _clients
                .Where(c => c.IsConnected)
                .Select(c => c.SendMessageAsync(message));
            await Task.WhenAll(tasks);
        }
    }
}
