using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class SeatRepository : AbsRepository, ISeatRepository
    {
        public SeatRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<bool> AssignSeatAsync(int seatId)
        {
            await using var conn = CreateConnection();
            await conn.OpenAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = @"UPDATE Seats SET IsAssigned = 1 WHERE SeatId = @SeatId AND IsAssigned = 0;";
            cmd.Parameters.AddWithValue("@SeatId", seatId);
            int rowsAffected = await cmd.ExecuteNonQueryAsync();
            return rowsAffected > 0;

        }

        public async Task<Seat> GetByIdAsync(int seatId)
        {
            await using var conn = CreateConnection();
            await conn.OpenAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT * FROM Seats WHERE SeatId = @SeatId;";
            cmd.Parameters.AddWithValue("@SeatId", seatId);
            await using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Seat
                {
                    SeatId = reader.GetInt32(0),
                    FlightId = reader.GetInt32(1),
                    SeatNumber = reader.GetString(2),
                    IsAssigned = reader.GetBoolean(3)
                };
            }
            return null;
        }

        public Task GetSeatsByFlightId(string v)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Seat>> GetSeatsByFlightIdAsync(string flightId)
        {
            List<Seat> seats = new List<Seat>();

            await using var conn = CreateConnection();
            await conn.OpenAsync();

            await using var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT * FROM Seats WHERE FlightId = @FlightId;";
            cmd.Parameters.AddWithValue("@FlightId", flightId);
            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                seats.Add(new Seat
                {
                    SeatId = reader.GetInt32(0),
                    FlightId = reader.GetInt32(1), 
                    SeatNumber = reader.GetString(2),
                    IsAssigned = reader.GetBoolean(3)
                });
            }

            return seats;
        }
    }
}
