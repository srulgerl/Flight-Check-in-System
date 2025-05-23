// Server/Program.cs
using Data.Repositories;

using Services.BusinessLogic;

namespace Web.Server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container  
        builder.Services.AddSignalR();
        ;
        builder.Services.AddHostedService<Worker>();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();

            });
        });

       
        var connectionString =
            builder.Configuration.GetConnectionString("DefaultConnection");

        // … (Controllers, SignalR, Swagger зэрэг бүртгэлүүд)
        builder.Services.AddHostedService<Worker>();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();

            });
        });

        // 2. Репозиторуудыг factory-ээр бүртгэх
        builder.Services.AddScoped<IFlightRepository>(sp =>
            new FlightRepository(connectionString));
        builder.Services.AddScoped<IBoardingPassRepository>(sp =>
            new BoardingPassRepository(connectionString));
        builder.Services.AddScoped<IPassengerRepository>(sp =>
            new PassengerRepository(connectionString));
        builder.Services.AddScoped<ISeatRepository>(sp =>
            new SeatRepository(connectionString));

        // 3. Бизнес логик болон бусад сервисүүд
        builder.Services.AddScoped<IFlightService, FlightStatusService>();
        builder.Services.AddScoped<ICheckInService, CheckInService>();
        builder.Services.AddScoped<SeatCommandProcessor>();

        // 4. SocketServer болон HostedService
        builder.Services.AddSingleton<CheckInSocketServer>();
        builder.Services.AddHostedService<SocketBackgroundService>();

        var app = builder.Build();
        // Configure the HTTP request pipeline  
        app.UseCors("CorsPolicy");

        //if (app.Environment.IsDevelopment())
        //{
        //    app.UseDeveloperExceptionPage();
        //}
        app.UseCors("CorsPolicy");

        app.MapHub<FlightStatusHub>("/flightStatusHub");


        app.Run();
    }
}
