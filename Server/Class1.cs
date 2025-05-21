using Data.Models;
using Data.Repositories;
using Microsoft.AspNetCore.ResponseCompression;
using Web.Server.Hubs;
using Services.BusinessLogic;
using Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//builder.Services.AddSingleton<FlightStatusService>();
builder.Services.AddScoped<IFlightRepository, FlightRepository>();

// Add SignalR for real-time updates
builder.Services.AddSignalR();
builder.Services.AddSingleton<SignalRClient>();


// Add Response Compression for SignalR
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseResponseCompression();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapHub<FlightStatusHub>("/flightstatushub");
app.MapFallbackToPage("/_Host");

app.Run();