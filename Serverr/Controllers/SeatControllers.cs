using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Server

{
    [ApiController]
    [Route("api/[controller]")]
    class SeatControllers : ControllerBase
    {
        private readonly ISeatRepository _repo;
        public SeatControllers(ISeatRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("by-flight/{flight-id")]
        public async Task<IActionResult> GetByFlight(string flightId)
        {
            var result = await _repo.GetSeatsByFlightIdAsync(flightId);
            return Ok(result);
        }

    }
}
