using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportCarpool.Models
{
    public class SchipholFlight
    {
        public int FlightId { get; set; }
        public string ArrDep { get; set; }
        public string Prefix { get; set; }
        public string PrefixIATA { get; set; }
        public string PRefixICAO { get; set; }
        public string Suffix { get; set; }
        public DateTime ScheduleDate { get; set; }
        public DateTime ScheduleTime { get; set; }

    }
}