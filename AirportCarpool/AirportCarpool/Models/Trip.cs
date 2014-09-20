using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirportCarpool.Models
{
    public class Trip
    {
        //test tce
        public int TripId { get; set; }
        public int MaxSeats { get; set; }
        public int MaxLuggage { get; set; }
        public DateTime ArrivalOnAirport { get; set; }
        public int MaxKm { get; set; }
        public string Status { get; set; }
        public TripType TripType { get; set; }
    }
}
