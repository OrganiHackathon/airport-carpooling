using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AirportCarpool.Models {
    public class NewTrip {
        [DisplayName("From")]
        public string LocationFrom { get; set; }
        
        [DisplayName("Street")]
        public string StreetFrom { get; set; }
        
        [DisplayName("Street number")]
        public string StreetNrFrom { get; set; }
        
        [DisplayName("Postal code")]
        public string PostalCodeFrom { get; set; }
        
        [DisplayName("City")]
        public string CityFrom { get; set; }
        
        [DisplayName("Country")]
        public string CountryFrom { get; set; }

        [DisplayName("To")]
        public string LocationTo { get; set; }

        [DisplayName("Street")]
        public string StreetTo { get; set; }

        [DisplayName("Street number")]
        public string StreetNrTo { get; set; }

        [DisplayName("Postal code")]
        public string PostalCodeTo { get; set; }

        [DisplayName("City")]
        public string CityTo { get; set; }

        [DisplayName("Country")]
        public string CountryTo { get; set; }

        [DisplayName("I can drive")]
        public bool Driver { get; set; }

        [DisplayName("I want to drive along")]
        public bool Passenger { get; set; }

        [DisplayName("Seats I need")]
        [Range(1, 100)]
        public int Seats { get; set; }

        [DisplayName("Pieces of luggage")]
        [Range(0, 100)]
        public int Luggage { get; set; }

        [DisplayName("Seats I have")]
        [Range(2, 100)]
        public int MaxSeats { get; set; }

        [DisplayName("Pieces of luggage I can take")]
        [Range(0, 100)]
        public int MaxLuggage { get; set; }

        [DisplayName("Maximum distance to pick up passengers (km)")]
        [Range(0, 1000)]
        public int MaxKm { get; set; }

        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime MovementDate { get; set; }

        [DisplayName("Time")]
        [DataType(DataType.Time)]
        public DateTime MovementTime { get; set; }

        [DisplayName("Departure or arrival")]
        public string MovementDateType { get; set; } // Departure / Arrival

        [DisplayName("Flight number")]
        public string FlightNumber { get; set; }

        [DisplayFormat(DataFormatString = "{0:t}")]
        public DateTime Departure { get; set; }

        [DisplayFormat(DataFormatString = "{0:t}")]
        public DateTime Arrival { get; set; }

        public string ArrDep { get; set; }


        public NewTrip() {
            Seats = 1;
            MaxSeats = 5;
            MaxLuggage = 3;
            MaxKm = 100;
        }
    }
}