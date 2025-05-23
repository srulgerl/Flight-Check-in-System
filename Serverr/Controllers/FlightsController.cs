// File: Serverr/Controllers/FlightsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Services.BusinessLogic;
using Serverr.Hubs;
using System.Text.Json;

namespace Serverr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly IHubContext<FlightStatusHub> _hubContext;
        private readonly IFlightService _flightService;

        public FlightsController(IHubContext<FlightStatusHub> hubContext, IFlightService flightService)
        {
            _hubContext = hubContext;
            _flightService = flightService;
        }

        // GET: api/flights
        [HttpGet]
        public async Task<IActionResult> GetFlights()
        {
            var flights = await _flightService.GetAllFlightsAsync();
            return Ok(flights);
        }

        // PUT: api/flights/{id}/status
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateFlightStatus(int id, [FromBody] string status)
        {
            await _flightService.UpdateFlightStatusAsync(id, status);

            var payload = JsonSerializer.Serialize(new
            {
                FlightId = id.ToString(),
                Status = status
            });

            await _hubContext.Clients.All.SendAsync("ReceiveFlightStatus", payload);

            return NoContent();
        }
    }
}
