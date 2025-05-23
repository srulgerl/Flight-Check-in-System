// File: Server/Program.cs
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Data.Repositories;
using Services.BusinessLogic;
using Serverr.Hubs;
using Serverr.SocketServer;

namespace Web.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configuration
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Core services
            builder.Services.AddControllers();
            builder.Services.AddSignalR();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            // Hosted background worker (optional if needed)
            builder.Services.AddHostedService<Worker>();

            // Socket + Seat command logic
            builder.Services.AddScoped<SeatCommandProcessor>();
            builder.Services.AddSingleton<CheckInSocketServer>();
            builder.Services.AddHostedService<SocketBackgroundService>(); // must inherit from BackgroundService

            // Repositories
            builder.Services.AddScoped<IFlightRepository>(_ => new FlightRepository(connectionString));
            builder.Services.AddScoped<IBoardingPassRepository>(_ => new BoardingPassRepository(connectionString));
            builder.Services.AddScoped<IPassengerRepository>(_ => new PassengerRepository(connectionString));
            builder.Services.AddScoped<ISeatRepository>(_ => new SeatRepository(connectionString));

            // Business logic
            builder.Services.AddScoped<IFlightService, FlightStatusService>();
            builder.Services.AddScoped<ICheckInService, CheckInService>();

            var app = builder.Build();

            // Middleware pipeline
            app.UseCors("CorsPolicy");
            app.MapControllers();
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");
            app.MapHub<FlightStatusHub>("/flightStatusHub");
            app.MapHub<SeatAllocationHub>("/seatHub");

            app.Run();
        }
    }
}
