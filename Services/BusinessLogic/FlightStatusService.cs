using Data.Models;
using Data.Repositories;
using Services.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    /// <summary>
    /// Service for managing flight status
    /// </summary>
    public class FlightStatusService: IFlightService
    {
        private readonly IFlightRepository _flightRepository;
        public FlightStatusService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }
        /// <summary>
        /// Change flight status
        /// </summary>
        /// <param name="flightId"></param>
        /// <param name="newStatus"></param>
        /// <returns></returns>
        public async Task<bool> ChangeFlightStatusAsync(int flightId , FlightStatus newStatus)
        {
            var flight = _flightRepository.GetByIdAsync(flightId);
            if (flight == null) return false;

            await _flightRepository.UpdateFlightStatusAsync(flightId, newStatus);
            return true;
                

        }
        /// <summary>
        /// Get all flights
        /// </summary>
        /// <returns></returns>
        public async Task<List<Flight>> GetAllFlightsAsync()
        {
            return await _flightRepository.GetAllAsync();
        }

        /// <summary>
        /// Get flight by id
        /// </summary>
        /// <param name="flightId"></param>
        /// <returns></returns>
        public async Task<Flight> GetFlightByIdAsync(int flightId)
        {
            return await _flightRepository.GetByIdAsync(flightId);
        }
    }
}
