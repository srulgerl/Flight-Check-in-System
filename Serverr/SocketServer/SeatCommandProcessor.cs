// Server/SocketServer/SeatCommandProcessor.cs
using Services.BusinessLogic;
using System.Net.Sockets;
using System.Text.Json;


namespace Web.Server
{
    public class SeatCommandProcessor
    {
        private readonly ICheckInService _checkInService;

        public SeatCommandProcessor(ICheckInService checkInService)
        {
            _checkInService = checkInService;
        }

        public async Task<string> ProcessAsync(string jsonMessage)
        {
            try
            {
                var command = JsonSerializer.Deserialize<SeatCommand>(jsonMessage);
                if (command == null || command.action != "reserveSeat")
                {
                    return BuildError("Invalid command format.");
                }

                bool success = await _checkInService.CheckInPassengerAsync(
                    command.passengerId,
                    command.flightId,
                    command.seatNumber
                );

                if (success)
                {
                    return BuildSuccess($"Seat {command.seatNumber} reserved successfully for passenger {command.passengerId}.");
                }
                else
                {
                    return BuildError($"Seat {command.seatNumber} is already reserved or check-in failed.");
                }
            }
            catch (Exception ex)
            {
                return BuildError("Server error: " + ex.Message);
            }
        }
        



        private string BuildSuccess(string message) =>
            JsonSerializer.Serialize(new { status = "success", message });

        private string BuildError(string message) =>
            JsonSerializer.Serialize(new { status = "error", message });
    }

    public class SeatCommand
    {
        public string action { get; set; } = "";
        public int flightId { get; set; }
        public int passengerId { get; set; }
        public string seatNumber { get; set; } = "";
    }
}
