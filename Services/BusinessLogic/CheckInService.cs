using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BusinessLogic
{
    public class CheckInService : ICheckInService
    {
        private readonly IPassengerRepository _passengerRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly IBoardingPassRepository _boardingPassRepository;

        public CheckInService(IPassengerRepository passengerRepository, ISeatRepository seatRepository, IBoardingPassRepository boardingPassRepository)
        {
            _passengerRepository = passengerRepository;
            _seatRepository = seatRepository;
            _boardingPassRepository = boardingPassRepository;
        }

        /// <summary>
        /// Check in a passenger by their passport number and assign them a seat.
        /// </summary>
        /// <param name="passportNumber"></param>
        /// <param name="seatId"></param>
        /// <returns></returns>
        public async Task<bool> CheckInPassengerAsync(string flightId, string passportNumber, int seatId)
        {
            //var fli = await _passengerRepository.GetPassengersByFlghtIdAsync(flightNumber);  
           var passenger = await _passengerRepository.GetPassengerByPassportAsync(passportNumber);
           if (passenger == null)
           {
               return false;
           }
           var seat = await _seatRepository.GetByIdAsync(seatId);
           if (seat == null || !seat.IsAssigned)
           {
               return false;
           }
          
           var assigned = await _seatRepository.AssignSeatAsync(seatId);
           if(!assigned) return false;

          
           var boardingPass = new BoardingPass
           {
               PassengerId = passenger.PassengerId,
               FlightId = passenger.FlightId,
               SeatId = seat.SeatId,
               IssuedAt = DateTime.UtcNow
           };
           return await _boardingPassRepository.CreateAsync(boardingPass);
        }
        
    }
}
