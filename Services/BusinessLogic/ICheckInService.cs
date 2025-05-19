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
    }
}
