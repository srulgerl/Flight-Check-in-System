using Data.Models;
using Data.Repositories;
using System.Reflection;

public class PassengerRepository : AbsRepository, IPassengerRepository
{
    public PassengerRepository(string connStr) : base(connStr) { }

    public async Task<List<Passenger>> GetAllAsync()
    {
        List<Passenger> list = new List<Passenger>();
        await using var db = CreateConnection();
        await db.OpenAsync();
        await using var cmd = db.CreateCommand();
        cmd.CommandText = @"SELECT * FROM Passengers;";
        await using var reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            list.Add(new Passenger
            {
                PassengerId = reader.GetInt32(0),
                PassportNumber = reader.GetString(1),
                FirstName = reader.GetString(2),
                LastName = reader.GetString(3),
                FlightId = reader.GetInt32(4),
            });
        }
        return list;
    }

    public async Task<Passenger> GetPassengerByPassportAsync(string passportNumber)
    {
        await using var db = CreateConnection();
        await db.OpenAsync();
        await using var cmd = db.CreateCommand();
        cmd.CommandText = @"SELECT * FROM Passengers WHERE PassportNumber = @PassportNumber;";
        cmd.Parameters.AddWithValue("@PassportNumber", passportNumber);
        await using var reader = await cmd.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            return new Passenger
            {
                PassengerId = reader.GetInt32(0),
                PassportNumber = reader.GetString(1),
                FirstName = reader.GetString(2),
                LastName = reader.GetString(3),
                FlightId = reader.GetInt32(4),
            };
        }
        return null;
    }


    public async Task<List<Passenger>> GetPassengersByFlightIdAsync(int flightId)
    {
        List<Passenger> passengerList = new List<Passenger>();
        await using var conn = CreateConnection();
        await conn.OpenAsync();
        await using var cmd = conn.CreateCommand();
        cmd.CommandText = @"SELECT * FROM Passengers WHERE FlightId = @FlightId;";
        cmd.Parameters.AddWithValue("@FlightId", flightId);
        await using var reader = await cmd.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            passengerList.Add(new Passenger
            {
                PassengerId = reader.GetInt32(0),
                PassportNumber = reader.GetString(1),
                FirstName = reader.GetString(2),
                LastName = reader.GetString(3),
                FlightId = reader.GetInt32(4),
            });
        }
        return passengerList;
    }

    public async Task<Passenger> GetPassengerByFlightIdAsync(int flightId)
    {
        await using var db = CreateConnection();
        await db.OpenAsync();
        await using var cmd = db.CreateCommand();
        cmd.CommandText = @"SELECT * FROM Passengers WHERE FlightId = @FlightId;";
        cmd.Parameters.AddWithValue("@FlightId", flightId);
        await using var reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            return new Passenger
            {
                PassengerId = reader.GetInt32(0),
                PassportNumber = reader.GetString(1),
                FirstName = reader.GetString(2),
                LastName = reader.GetString(3),
                FlightId = reader.GetInt32(4),
            };
        }
        return null;
    }
    public async Task<Passenger> GetPassengerByPassportAndFlightAsync(string passportNumber, int flightId)
    {
        await using var db = CreateConnection();
        await db.OpenAsync();
        await using var cmd = db.CreateCommand();
        cmd.CommandText = @"SELECT * FROM Passengers WHERE PassportNumber = @PassportNumber AND FlightId = @FlightId;";
        cmd.Parameters.AddWithValue("@PassportNumber", passportNumber);
        cmd.Parameters.AddWithValue("@FlightId", flightId);
        await using var reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            return new Passenger
            {
                PassengerId = reader.GetInt32(0),
                PassportNumber = reader.GetString(1),
                FirstName = reader.GetString(2),
                LastName = reader.GetString(3),
                FlightId = reader.GetInt32(4),
            };
        }
        return null;
    }

    public async Task<Passenger> GetPassengerByIdAsync(int passengerId)
    {
        await using var db = CreateConnection();
        await db.OpenAsync();
        await using var cmd = db.CreateCommand();
        cmd.CommandText = @"SELECT * FROM Passengers WHERE PassengerId = @PassengerId;";
        cmd.Parameters.AddWithValue("@PassengerId", passengerId);
        await using var reader = await cmd.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            return new Passenger
            {
                PassengerId = reader.GetInt32(0),
                PassportNumber = reader.GetString(1),
                FirstName = reader.GetString(2),
                LastName = reader.GetString(3),
                FlightId = reader.GetInt32(4),
            };
        }
        return null;
    }
}
