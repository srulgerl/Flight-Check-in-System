using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
// Other necessary using statements

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
// For hosted WebAssembly, add:
// builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseWebAssemblyDebugging(); // For hosted WebAssembly
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles(); // For hosted WebAssembly
app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();
app.MapControllers(); // For hosted WebAssembly
app.MapBlazorHub(); // For Blazor Server
app.MapFallbackToPage("/_Host"); // For Blazor Server
// OR for hosted WebAssembly:
// app.MapFallbackToFile("index.html");

app.Run();