// File: WinForm/Services/SocketClient.cs
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace WinForm.Services
{
    public class SocketClient
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private CancellationTokenSource _cts;
        private Task _receiveTask;
        private HubConnection? _hubConnection;

        public event Action<string>? OnMessageReceived;

        public bool IsConnected => _client?.Connected ?? false;

        public async Task<bool> ConnectAsync(string host = "127.0.0.1", int port = 9000, string hubUrl = "http://localhost:5000/seatHub")
        {
            try
            {
                _client = new TcpClient();
                await _client.ConnectAsync(host, port);
                _stream = _client.GetStream();

                _cts = new CancellationTokenSource();
                _receiveTask = Task.Run(() => ListenAsync(_cts.Token));

                _hubConnection = new HubConnectionBuilder()
                    .WithUrl(hubUrl)
                    .WithAutomaticReconnect()
                    .Build();

                await _hubConnection.StartAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Connection failed: {ex.Message}");
                return false;
            }
        }
        public async Task<string?> ReceiveAsync()
        {
            var buffer = new byte[1024];
            var sb = new StringBuilder();

            try
            {
                while (_client.Connected)
                {
                    int bytes = await _stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytes == 0) return null;

                    sb.Append(Encoding.UTF8.GetString(buffer, 0, bytes));
                    if (sb[^1] == '\n') break;
                }

                return sb.ToString().TrimEnd('\r', '\n');
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ ReceiveAsync error: {ex.Message}");
                return null;
            }
        }

        public async Task SendAsync(string message)
        {
            if (!IsConnected || _stream == null) return;

            try
            {
                var data = Encoding.UTF8.GetBytes(message + "\n");
                await _stream.WriteAsync(data, 0, data.Length);
                await _stream.FlushAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error sending message: {ex.Message}");
            }
        }

        private async Task ListenAsync(CancellationToken token)
        {
            var buffer = new byte[1024];
            var sb = new StringBuilder();

            try
            {
                while (!token.IsCancellationRequested && _client.Connected)
                {
                    int bytes = await _stream.ReadAsync(buffer, 0, buffer.Length, token);
                    if (bytes == 0) break;

                    sb.Append(Encoding.UTF8.GetString(buffer, 0, bytes));
                    if (sb[^1] == '\n')
                    {
                        var fullMessage = sb.ToString().TrimEnd('\r', '\n');
                        OnMessageReceived?.Invoke(fullMessage);

                        if (_hubConnection?.State == HubConnectionState.Connected)
                        {
                            await _hubConnection.SendAsync("BroadcastSeatUpdate", fullMessage);
                        }

                        sb.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Listener error: {ex.Message}");
            }
        }

        public async void Disconnect()
        {
            try
            {
                _cts?.Cancel();
                _stream?.Close();
                _client?.Close();
                if (_hubConnection != null)
                {
                    await _hubConnection.StopAsync();
                    await _hubConnection.DisposeAsync();
                }
                Console.WriteLine("🛑 Disconnected from server and SignalR hub");
            }
            catch { }
        }
    }
}
