using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BusinessLogic
{
    public interface IFlightService
    {
        Task<Flight> GetFlightByIdAsync(int flightId);
        Task<List<Flight>> GetAllFlightsAsync();
        Task<bool> ChangeFlightStatusAsync(int flightId, FlightStatus status);
        Task UpdateFlightStatusAsync(int id, string status);
    }
}
