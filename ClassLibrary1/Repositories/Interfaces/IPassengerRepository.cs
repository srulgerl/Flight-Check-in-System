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
        Task<List<Passenger>> GetPassengersByFlghtIdAsync(string flightId);
    }
}
