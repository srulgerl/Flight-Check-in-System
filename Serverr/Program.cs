// Server/Program.cs
using Data.Repositories;
using Server.SocketServer;
using Services.BusinessLogic;

var builder = WebApplication.CreateBuilder(args);

// REST API + SignalR
builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORE services
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<ICheckInService, CheckInService>();
builder.Services.AddScoped<FlightStatusService>();
builder.Services.AddScoped<SeatCommandProcessor>();

// SocketServer (hosted service)
builder.Services.AddSingleton<CheckInSocketServer>();
builder.Services.AddHostedService<SocketBackgroundService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.MapHub<FlightStatusHub>("/flightHub");

app.Run();
