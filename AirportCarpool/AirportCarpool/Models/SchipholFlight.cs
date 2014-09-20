using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AirportCarpool.Models
{
    [DataContract]
    public class SchipholFlight
    {
       
        public int FlightId { get; set; }
          [DataMember]
        public string FlightNumber { get; set; }
         [DataMember]
        public string ArrDep { get; set; }
         [DataMember]
        public string Prefix { get; set; }
         [DataMember]
        public string PrefixIATA { get; set; }
         [DataMember]
        public string PRefixICAO { get; set; }
         [DataMember]
        public string Suffix { get; set; }
         [DataMember]
        public DateTime ScheduleDate { get; set; }
         [DataMember]
        public DateTime ScheduleTime { get; set; }

    }
}
