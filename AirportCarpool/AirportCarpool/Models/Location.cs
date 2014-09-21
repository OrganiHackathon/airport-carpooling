﻿using System;
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
            Street = string.Empty;
            StreetNr = string.Empty;
            PostalCode = string.Empty;
            City = string.Empty;
            Country = string.Empty;
            Geolocation = string.Empty;
        }
    }
}