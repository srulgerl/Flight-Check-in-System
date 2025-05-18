using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Data.Models
{
    public class Seat
    {
        public int SeatId { get; set; }
        public int FlightId { get; set; }
        public string SeatNumber { get; set; }

        public bool IsAssigned { get; set; }
    }
}
