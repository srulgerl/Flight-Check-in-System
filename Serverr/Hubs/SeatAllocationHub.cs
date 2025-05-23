using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Server;
    public class SeatAllocationHub : Hub
    {
        public async Task NotifySeatAllocatioln(int flightId, int seatId)
        {
            // Notify all connected clients about the seat allocation
            await Clients.All.SendAsync("SeatTaken", flightId, seatId);
        }
    }

