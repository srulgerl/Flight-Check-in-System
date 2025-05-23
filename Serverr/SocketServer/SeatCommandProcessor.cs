// File: Serverr/SocketServer/SeatCommandProcessor.cs
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Serverr.SocketServer
{
    public class SeatCommandProcessor
    {
        private readonly ConcurrentDictionary<string, string> _seatMap = new();

        public async Task<string> ProcessAsync(string command)
        {
            // Example: command = "BOOK:FL123:12A:1234567890"
            try
            {
                var parts = command.Split(':');
                if (parts.Length != 4 || parts[0] != "BOOK")
                    return "❌ Invalid command format.";

                var flightId = parts[1];
                var seatId = parts[2];
                var passengerId = parts[3];

                var seatKey = $"{flightId}-{seatId}";
                if (_seatMap.TryAdd(seatKey, passengerId))
                {
                    return $"✅ Seat {seatId} reserved for passenger {passengerId} on flight {flightId}.";
                }
                else
                {
                    return $"⚠️ Seat {seatId} on flight {flightId} is already booked.";
                }
            }
            catch (Exception ex)
            {
                return $"❌ Error processing command: {ex.Message}";
            }
        }
    }
}
