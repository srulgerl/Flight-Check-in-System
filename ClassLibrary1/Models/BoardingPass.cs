using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class BoardingPass
    {
        public int Id { get; set; }
        public int PassengerId { get; set; }
        public int FlightId { get; set; }
        public int SeatId { get; set; }
        public DateTime IssuedAt { get; set; }

        // Add the missing property to fix CS0117  
        public string PassengerName { get; set; }
        public string FlightNumber { get; set; }
        public string SeatNumber { get; set; }
        public DateTime PrintedAt { get; set; }
    }
}
