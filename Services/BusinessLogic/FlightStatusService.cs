using Data.Models;
using Data.Repositories;
using Microsoft.AspNetCore.SignalR;
using Server.Hubs;

namespace Services.BusinessLogic
{
    public class FlightStatusService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IHubContext<FlightStatusHub> _hubContext;

        // Constructor – repository болон SignalR context inject хийнэ
        public FlightStatusService(IFlightRepository flightRepository, IHubContext<FlightStatusHub> hubContext)
        {
            _flightRepository = flightRepository;
            _hubContext = hubContext;
        }

        // Нислэгийн төлөв өөрчлөх
        public async Task<bool> ChangeFlightStatusAsync(int flightId, FlightStatus newStatus)
        {
            var flight = await _flightRepository.GetByIdAsync(flightId);
            if (flight == null) return false;

            await _flightRepository.UpdateFlightStatusAsync(flightId, newStatus);

            // 🟢 Real-time мэдэгдэл клиент рүү дамжуулах
            await _hubContext.Clients.All.SendAsync("FlightStatusChanged", flightId, newStatus.ToString());

            return true;
        }

        // Бүх нислэгүүдийг авах
        public async Task<List<Flight>> GetAllFlightsAsync()
        {
            return await _flightRepository.GetAllAsync();
        }

        // ID-р нислэг авах
        public async Task<Flight> GetFlightByIdAsync(int flightId)
        {
            return await _flightRepository.GetByIdAsync(flightId);
        }
    }
}
