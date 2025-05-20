using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Server.Hubs; // Make sure this using is present

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllers(); // For API controllers

// Register your repositories and other services here
// builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapBlazorHub();
app.MapHub<FlightStatusHub>("/flightstatushub");     // ✨ Flight статус дамжуулах hub
app.MapFallbackToPage("/_Host");

app.Run();
