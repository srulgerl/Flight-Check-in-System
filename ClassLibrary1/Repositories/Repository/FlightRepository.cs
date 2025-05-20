using Data.Models;
using Data.Repositories;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
    {
        public class FlightRepository: AbsRepository, IFlightRepository
        {

        public FlightRepository(string connStr) : base(connStr) { }

        public async Task<List<Flight>> GetAllAsync()
        {
            var flights = new List<Flight>();
            await using var conn = CreateConnection();
            await conn.OpenAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Flights;";
            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                flights.Add(new Flight
                {
                    FlightId = reader.GetInt32(0),
                    FlightNumber = reader.GetString(1),
                    Departure = reader.GetString(2),
                    Arrival = reader.GetString(3),
                    DepartureDate = reader.GetDateTime(4),
                    ArrivalDate = reader.GetDateTime(5),
                    Status = Enum.Parse<FlightStatus>(reader.GetString(6))
                });
            }
            return flights;
        }

        public async Task<Flight> GetByIdAsync(int id)
        {
            await using var db = CreateConnection();
            await db.OpenAsync();
            await using var cmd = db.CreateCommand();
            cmd.CommandText = "SELECT * FROM Flights WHERE FlightId = @Id;";
            cmd.Parameters.AddWithValue("@Id", id);
            await using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Flight
                {
                    FlightId = reader.GetInt32(0),
                    FlightNumber = reader.GetString(1),
                    Departure = reader.GetString(2),
                    Arrival = reader.GetString(3),
                    DepartureDate = reader.GetDateTime(4),
                    ArrivalDate = reader.GetDateTime(5),
                    Status = Enum.Parse<FlightStatus>(reader.GetString(6))
                };
            }
            return null;
        }

        public async Task<Passenger> GetPassengerByFlightIdAsync(int flightId)
        {
            await using var conn = CreateConnection();
            await conn.OpenAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT PassengerId, PassportNumber, FirstName, LastName, FlightId FROM Passengers WHERE FlightId = @FlightId;";
            cmd.Parameters.AddWithValue("@FlightId", flightId);
            await using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Passenger
                {
                    PassengerId = reader.GetInt32(0),
                    PassportNumber = reader.GetString(1),
                    FirstName = reader.GetString(2),
                    LastName = reader.GetString(3),
                    FlightId = reader.GetInt32(4)
                };

            }
            return null;
        }

        public async Task UpdateFlightStatusAsync(int flightId, FlightStatus status)
        {
            await using var db = CreateConnection();
            await db.OpenAsync();
            await using var cmd = db.CreateCommand();
            cmd.CommandText = @"
                UPDATE Flights
                SET Status = @Status
                WHERE FlightId = @FlightId;";
            cmd.Parameters.AddWithValue("@Status", status);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<Flight> GetFlightByNumberAsync(string flightNumber)
        {
            await using var conn = CreateConnection();
            await conn.OpenAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * Flight WHERE FlightNumber = @FlightNumber;";
            cmd.Parameters.AddWithValue("@FlightNumber", flightNumber);
            await using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Flight
                {
                    FlightId = reader.GetInt32(0),
                    FlightNumber = reader.GetString(1),
                    Departure = reader.GetString(2),
                    Arrival = reader.GetString(3),
                    DepartureDate = reader.GetDateTime(4),
                    ArrivalDate = reader.GetDateTime(5),
                    Status = Enum.Parse<FlightStatus>(reader.GetString(6))
                };
            }
            return null;
        }


    }

}
