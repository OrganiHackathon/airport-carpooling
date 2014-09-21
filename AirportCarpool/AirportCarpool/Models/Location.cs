using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportCarpool.Models {
    public class Location {
        public int LocationId { get; set; }
        public string Street { get; set; }
        public string StreetNr { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Geolocation { get; set; }

        public Location() {

        }

        public static Location GetCopy(Location location) {
            return new Location {
                Street = location.Street,
                StreetNr = location.StreetNr,
                PostalCode = location.PostalCode,
                City = location.City,
                Country = location.Country,
                Geolocation = location.Geolocation
            };
        }

        public static Location GetNewSchipholLocation() {
            return new Location {
                Street = "Evert van der Beekstraat",
                StreetNr = "202",
                PostalCode = "1118 CP",
                City = "Schiphol",
                Country = "Nederland"
            };
        }
    }
}