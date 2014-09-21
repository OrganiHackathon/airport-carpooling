using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Column(TypeName="datetime2")]
        public DateTime Departure { get; set; }

        [DisplayFormat(DataFormatString = "{0:t}")]
        [Column(TypeName = "datetime2")]
        public DateTime Arrival { get; set; }

        public string ArrDep { get; set; }

        public string Summary() {
            var time = "";
            if (ArrDep == "D") {
                time = Departure.ToShortTimeString();
            } else {
                time = Arrival.ToShortTimeString();
            }
            return FlightNumber + " - " + time;
        }

    }
}