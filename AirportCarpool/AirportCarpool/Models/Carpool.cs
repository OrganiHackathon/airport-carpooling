using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportCarpool.Models {

    public enum CarpoolStatus{
        Full,       
        New
    }

    public class Carpool {
        public int CarpoolId { get; set; }
        public int MaxSeats { get; set; }
        public int MaxLuggage { get; set; }
        public int MaxKm { get; set; }
        public DateTime Arrival { get; set; }
        public CarpoolStatus Status { get; set; }

    }
}