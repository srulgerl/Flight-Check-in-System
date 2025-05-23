using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Serverr.Hubs
{
    public class SeatAllocationHub : Hub
    {
        public async Task BroadcastSeatUpdate(string message)
        {
            await Clients.All.SendAsync("ReceiveSeatUpdate", message);
        }
    }
}
