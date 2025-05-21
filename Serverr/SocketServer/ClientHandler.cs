// Server/SocketServer/ClientHandler.cs
using System.Net.Sockets;
using System.Text;

namespace Server.SocketServer
{
    public class ClientHandler
    {
        private readonly TcpClient _client;
        private readonly NetworkStream _stream;
        private readonly Func<string, Task> _broadcast;

        public bool IsConnected => _client.Connected;

        public ClientHandler(TcpClient client, Func<string, Task> broadcast)
        {
            _client = client;
            _stream = _client.GetStream();
            _broadcast = broadcast;
        }

        public async Task ProcessAsync()
        {
            var buffer = new byte[1024];
            try
            {
                while (_client.Connected)
                {
                    int byteCount = await _stream.ReadAsync(buffer);
                    if (byteCount == 0) break;

                    var message = Encoding.UTF8.GetString(buffer, 0, byteCount);
                    Console.WriteLine($"📥 Message from client: {message}");

                    // Broadcast to all clients
                    await _broadcast(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Socket error: {ex.Message}");
            }
            finally
            {
                _stream.Close();
                _client.Close();
            }
        }

        public async Task SendMessageAsync(string message)
        {
            if (!_client.Connected) return;

            var data = Encoding.UTF8.GetBytes(message);
            try
            {
                await _stream.WriteAsync(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error sending to client: {ex.Message}");
            }
        }
    }
}
