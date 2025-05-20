using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IFlightRepository
    {
        Task<Flight> GetByIdAsync(int id);
     
        Task<List<Flight>> GetAllAsync();
     
        Task UpdateFlightStatusAsync( int flightId, FlightStatus status);

        Task<Passenger> GetPassengerByFlightIdAsync(int flightId);
        Task<Flight> GetFlightByNumberAsync(string flightNumber);



    }
}
