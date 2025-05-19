using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BusinessLogic
{
    public interface ICheckInService
    {
        Task<bool> CheckInPassengerAsync(string flightId, string passportNumber, int seatId);
        Task<bool> CheckInPassengerAsync(int currentPassengerId, int flightId, string? seatNumber);
        Task<IEnumerable<string>> GetOccupiedSeatsAsync(int flightId);
    }
}
