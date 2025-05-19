using System;
using System.Windows.Forms;
using Data;
using Data.Repositories;
using Services.BusinessLogic;
using WinForms.Forms;
using Microsoft.Extensions.DependencyInjection;
using SQLitePCL;

namespace Forms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();
            Batteries.Init();

            // DB init
            var dbInit = new DatabaseInitializer();
            if (!dbInit.Initialize())
                return; // Initialization failed, app stops

            string connectionString = dbInit.ConnectionString;

            var services = new ServiceCollection();

            // Dependency bindings with SQLite connection
            services.AddScoped<IPassengerRepository>(_ => new PassengerRepository(connectionString));
            // add others: SeatRepository, etc.
            //services.AddScoped<IPrintService, PrintService>();
            services.AddScoped<IFlightRepository>(_ => new FlightRepository(connectionString));
            services.AddScoped<ICheckInService, CheckInService>();
            services.AddScoped<ISeatRepository>(_ => new SeatRepository(connectionString));
            services.AddScoped<IBoardingPassRepository>(_ => new BoardingPassRepository(connectionString));

            services.AddScoped<CheckInForm>();

            var provider = services.BuildServiceProvider();
            Application.Run(provider.GetRequiredService<CheckInForm>());

        }
    }
}
