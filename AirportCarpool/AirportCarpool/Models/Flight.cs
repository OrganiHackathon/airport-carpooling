using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirportCarpool.Models {
    public class Flight : MovementDetail {
        public int FlightId { get; set; }
        public string FlightNumber { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DisplayFormat(DataFormatString = "{0:t}")]        
        public DateTime Departure { get; set; }
        [DisplayFormat(DataFormatString = "{0:t}")]        
        public DateTime Arrival { get; set; }        

    }
}