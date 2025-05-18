using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BoardingPassRepository: AbsRepository, IBoardingPassRepository
    {

        public BoardingPassRepository(string connStr) : base(connStr) { }

        public async Task<bool> CreateAsync(BoardingPass boardingPass )
        {
            await using var conn = CreateConnection();
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO BoardingPass (PassengerId, FlightId, SeatId, IssuedAt) VALUES (@PassengerId, @FlightId, @SeatId, @CheckInStatus);";
            
            cmd.Parameters.AddWithValue("@PassengerId", boardingPass.PassengerId);
            cmd.Parameters.AddWithValue("@FlightId", boardingPass.FlightId);
            cmd.Parameters.AddWithValue("@SeatId", boardingPass.SeatId);
            cmd.Parameters.AddWithValue("@IssuedAt", boardingPass.IssuedAt);
            int rowsAffected = await cmd.ExecuteNonQueryAsync();
            return rowsAffected > 0;
        }

        public async Task<BoardingPass> GetPassengerByIdAsync(int passengerId)
        {
            await using var conn = CreateConnection();
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT PassengerId, FlightId, SeatId, IssuedAt FROM BoardingPass WHERE PassengerId = @PassengerId;";

            cmd.Parameters.AddWithValue("@PassengerId", passengerId);
            await using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new BoardingPass
                {
                    PassengerId = reader.GetInt32(0),
                    FlightId = reader.GetInt32(1),
                    SeatId = reader.GetInt32(2),
                    IssuedAt = reader.GetDateTime(3)
                };
            }
            return null;
        }

      
    }
}
