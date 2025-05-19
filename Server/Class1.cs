using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Data;
using Data.Repositories;
using Services.BusinessLogic;
using Microsoft.AspNetCore.Components.Web;

public class Program { 
    public static Task Main(string[] args)
    { 
        //    var builder = WebAssemblyHostBuilder.CreateDefault(args);
        //    builder.RootComponents.Add<App>("#app");
        //    builder.RootComponents.Add<HeadOutlet>("head::after");

        //    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        //    await builder.Build().RunAsync();
    }
}