//using Data.Repositories;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Web.Server.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class PassengersController : ControllerBase
//    {
//        private readonly IPassengerRepository _repo;
//        public PassengersContoller(IPassengerRepository repo)
//        {
//            _repo = repo;
//        }

//        [HttpGet("by-passport/{passportNumber}")]
//        public async Task<IActionResult> GetByPassport(string passportNumber)
//        {
//            var passenger = await _repo.GetPassengerByPassportAsync(passportNumber);
//            if (passenger == null) return NotFound();
//            return Ok(passenger);
//        }

//        [HttpGet("by-flight/{flightId}")]
//        public async Task<IActionResult> GetByFlight(int flightId)
//        {
//            var passengers = await _repo.GetPassengersByFlightIdAsync(flightId); // Fix: Corrected method name to match the updated interface  
//            if (passengers == null || !passengers.Any()) return NotFound();
//            return Ok(passengers);
//        }
//    }
//}
