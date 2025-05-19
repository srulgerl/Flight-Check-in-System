using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface ISeatRepository
    {
        Task<Seat> GetByIdAsync(int seatId);
        Task<List<Seat>> GetSeatsByFlightIdAsync(string flightId);
        Task<bool> AssignSeatAsync(int seatId);
        Task GetSeatsByFlightId(string v);
    }
}
