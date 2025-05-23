// File: Serverr/SocketServer/ClientHandler.cs
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Web.Server;

namespace Serverr.SocketServer
{
    public class ClientHandler
    {
        private readonly TcpClient _client;
        private readonly NetworkStream _stream;
        private readonly SeatCommandProcessor _processor;
        private readonly ConcurrentDictionary<string, ClientHandler> _clients;

        public ClientHandler(TcpClient client, SeatCommandProcessor processor, ConcurrentDictionary<string, ClientHandler> clients)
        {
            _client = client;
            _stream = client.GetStream();
            _processor = processor;
            _clients = clients;
        }

        public async Task HandleClientAsync(string clientId, CancellationToken token)
        {
            var buffer = new byte[1024];
            try
            {
                while (!token.IsCancellationRequested && _client.Connected)
                {
                    int byteCount = await _stream.ReadAsync(buffer.AsMemory(0, buffer.Length), token);
                    if (byteCount == 0) break;

                    var message = Encoding.UTF8.GetString(buffer, 0, byteCount);
                    Console.WriteLine($"📥 Received from {clientId}: {message}");

                    var response = await _processor.ProcessAsync(message);
                    await BroadcastAsync(response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error [{clientId}]: {ex.Message}");
            }
            finally
            {
                Disconnect();
                _clients.TryRemove(clientId, out _);
            }
        }

        private async Task BroadcastAsync(string message)
        {
            var data = Encoding.UTF8.GetBytes(message);
            foreach (var kvp in _clients)
            {
                try
                {
                    if (kvp.Value != this && kvp.Value._client.Connected)
                    {
                        await kvp.Value._stream.WriteAsync(data);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Broadcast error to {kvp.Key}: {ex.Message}");
                }
            }
        }

        public void Disconnect()
        {
            try
            {
                _stream?.Close();
                _client?.Close();
            }
            catch { }
        }
    }
}
