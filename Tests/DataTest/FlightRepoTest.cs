using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Data.Repositories;

using Microsoft.Data.Sqlite;
using Data.Models;

namespace MyApp.Data.Tests
{
    [TestClass]
    public class FlightRepositoryTests
    {
        private FlightRepository _repo;
        private SqliteConnection _connection;

        [TestInitialize]
        public void Setup()
        {
            _connection = new SqliteConnection("Data Source=:memory:");
            _connection.Open();
            var cmd = _connection.CreateCommand();
            cmd.CommandText = @"
                CREATE TABLE Flights (
                    FlightID INTEGER PRIMARY KEY NOT NULL,
                    FlightNumber VARCHAR(10) NOT NULL UNIQUE,
                    Departure VARCHAR(50) NOT NULL,
                    Arrival VARCHAR(50) NOT NULL,
                    DepartureTime DATETIME NOT NULL,
                    ArrivalTime DATETIME NOT NULL,
                    Status VARCHAR(20) NOT NULL
                );";
            cmd.ExecuteNonQuery();
            _repo = new FlightRepository(_connection.ConnectionString);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _connection.Close();
            _connection.Dispose();
        }

        [TestMethod]
        public async Task CreateAsync_ShouldInsertAndReturnId()
        {
            var flight = new Flight
            {
                FlightNumber = "AB123",
                Departure = "CityA",
                Arrival = "CityB",
                DepartureDate = DateTime.UtcNow,
                ArrivalDate = DateTime.UtcNow.AddHours(2),
                Status = "Scheduled"
            };
            int id = await _repo.CreateAsync(flight);
            Assert.IsTrue(id > 0);
        }

        [TestMethod]
        public async Task GetAllAsync_ShouldReturnInsertedFlight()
        {
            var flight = new Flight
            {
                FlightNumber = "CD456",
                Departure = "CityC",
                Arrival = "CityD",
                DepartureDate = DateTime.UtcNow,
                ArrivalDate = DateTime.UtcNow.AddHours(3),
                Status = "Scheduled"
            };
            int id = await _repo.CreateAsync(flight);
            var all = (await _repo.GetAllFlightsAsync()).Select(f => f.FlightId).ToList();
            CollectionAssert.Contains(all, id);
        }

        [TestMethod]
        public async Task GetByIdAsync_ShouldReturnCorrectFlight()
        {
            var flight = new Flight
            {
                FlightNumber = "EF789",
                Departure = "CityE",
                Arrival = "CityF",
                DepartureDate = DateTime.UtcNow,
                ArrivalDate = DateTime.UtcNow.AddHours(4),
                Status = "Scheduled"
            };
            int id = await _repo.CreateAsync(flight);
            var fetched = await _repo.GetFlightByIdAsync(id);
            Assert.AreEqual("EF789", fetched.FlightNumber);
        }
    }
}
