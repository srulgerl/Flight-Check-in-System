﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Flight
    {
        public int FlightId { get; set; }
        public String FlightNumber { get; set; }
        public String Departure { get; set; }
        public String Arrival { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public FlightStatus Status { get; set; }
        public List<Seat> Seats { get; set; } = new List<Seat>();

    }
    public enum FlightStatus
    {
        CheckingIn,       // Бүртгэж байна
        Boarding,         // Онгоцонд сууж байна
        Departed,         // Ниссэн
        Delayed,          // Хойшилсон
        Cancelled         // Цуцалсан
    }

}
