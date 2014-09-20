using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportCarpool.Models {
    public class Movement {
        public int MovementId { get; set; }
        public User User { get; set; }
        public Location LocationFrom { get; set; }
        public Location LocationTo { get; set; }
        public bool Driver { get; set; }
        public bool Passenger { get; set; }
        public int Seats { get; set; }
        public int Luggage { get; set; }
        public int MaxSeats { get; set; }
        public int MaxLuggage { get; set; }
        public int MaxKm { get; set; }
        public DateTime MovementDateTime { get; set; }
        public string MovementDateType { get; set; } // Departure / Arrival
        public IList<MovementDetail> MovementDetails { get; set; }
    }
}