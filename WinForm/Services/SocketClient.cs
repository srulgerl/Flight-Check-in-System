// WinApp/Services/SocketClient.cs
using System.Net.Sockets;
using System.Text;

namespace WinForms.Services
{
    public class SocketClient
    {
        private TcpClient? _client;
        private NetworkStream? _stream;

        public bool IsConnected => _client?.Connected ?? false;

        public async Task<bool> ConnectAsync(string host, int port)
        {
            try
            {
                _client = new TcpClient();
                await _client.ConnectAsync(host, port);
                _stream = _client.GetStream();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task SendAsync(string message)
        {
            if (_stream == null || !_client!.Connected) return;

            var data = Encoding.UTF8.GetBytes(message);
            await _stream.WriteAsync(data);
        }

        public async Task<string?> ReceiveAsync()
        {
            if (_stream == null || !_client!.Connected) return null;

            var buffer = new byte[1024];
            int count = await _stream.ReadAsync(buffer);
            return Encoding.UTF8.GetString(buffer, 0, count);
        }

        public void Disconnect()
        {
            _stream?.Close();
            _client?.Close();
        }
    }
}
