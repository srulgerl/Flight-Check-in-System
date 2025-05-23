using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Services.BusinessLogic;

namespace Web.Server;

[ApiController]
[Route("api/[controller]")]
public class FlightsController : ControllerBase
{
    private readonly IHubContext<FlightStatusHub> _hubContext;
    // Датабазтай холбогдох сервис (жишээ нь)
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

    // PUT: api/flights/5/status
    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateFlightStatus(int id, [FromBody] string status)
    {
        // Нислэгийн төлөвийг өөрчлөх
        await _flightService.UpdateFlightStatusAsync(id, status);

        // SignalR ашиглан клиентүүдэд өөрчлөлтийг мэдэгдэх
        await _hubContext.Clients.All.SendAsync("FlightStatusChanged", id, status);

        return NoContent();
    }
}