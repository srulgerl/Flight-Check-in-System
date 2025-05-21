using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Services.BusinessLogic;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly FlightStatusService _flightService;
        private readonly IHubContext<FlightStatusHub> _hubContext;

        public FlightsController(FlightStatusService flightService, IHubContext<FlightStatusHub> hubContext)
        {
            _flightService = flightService;
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Flight>>> GetAll()
        {
            var flights = await _flightService.GetAllFlightsAsync();
            return Ok(flights);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> GetById(int id)
        {
            var flight = await _flightService.GetFlightByIdAsync(id);
            if (flight == null) return NotFound();
            return Ok(flight);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] FlightStatus newStatus)
        {
            var success = await _flightService.ChangeStatusAsync(id, newStatus);
            if (!success) return NotFound();

            await _hubContext.Clients.All.SendAsync("FlightStatusChanged", id, newStatus.ToString());
            return NoContent();
        }
    }
}
