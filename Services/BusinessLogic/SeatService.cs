using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BusinessLogic
{
    public class SeatService
    {
        public Task<bool> AssignSeatAsync(int seatId)
        {
            // Logic to assign a seat
            return Task.FromResult(true);
        }
    }
}
