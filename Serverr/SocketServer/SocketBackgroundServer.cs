using Microsoft.Extensions.Hosting;


namespace Web.Server
{
    public class SocketBackgroundService : BackgroundService
    {
        private readonly CheckInSocketServer _server;
        public SocketBackgroundService(CheckInSocketServer server)
            => _server = server;

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
            => _server.StartAsync(stoppingToken);
    }

}
