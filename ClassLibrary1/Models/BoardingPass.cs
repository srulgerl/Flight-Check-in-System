using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class BoardingPass
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PassengerId { get; set; }
        
        public int FlightId { get; set; }
        public int SeatId { get; set; }
        public DateTime IssuedAt { get; set; }
    }
}
