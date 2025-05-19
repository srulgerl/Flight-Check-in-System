using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IPassengerRepository
    {
        Task<List<Passenger>> GetAllAsync();
        Task<Passenger> GetPassengerByPassportAsync(string passportNumber);
        Task<List<Passenger>> GetPassengersByFlightIdAsync(int flightId);
        Task<Passenger> GetPassengerByFlightIdAsync(int flightId);
        Task<Passenger> GetPassengerByPassportAndFlightAsync(string passportNumber, int flightId);

    }
}
