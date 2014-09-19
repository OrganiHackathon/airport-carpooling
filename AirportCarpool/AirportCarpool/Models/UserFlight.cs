using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportCarpool.Models
{
    public class UserFlight
    {
        public int UserFlightid { get; set; }
        public Flight flight { get; set; }
        public User user { get; set; }
    }
}