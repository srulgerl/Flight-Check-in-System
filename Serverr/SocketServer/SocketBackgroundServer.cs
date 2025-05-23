// File: Serverr/SocketServer/SocketBackgroundService.cs
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.Net.Sockets;
using System.IO;

namespace Serverr.SocketServer
{
    public class SocketBackgroundService : BackgroundService
    {
        private readonly CheckInSocketServer _socketServer;

        public SocketBackgroundService(CheckInSocketServer socketServer)
        {
            _socketServer = socketServer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _socketServer.StartAsync(stoppingToken);
        }
    }
    
}