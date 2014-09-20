using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportCarpool.Models {
    public class Flight : MovementDetail {
        public int FlightId { get; set; }
        public string FlightNumber { get; set; }
        public DateTime Date { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }

    }
}