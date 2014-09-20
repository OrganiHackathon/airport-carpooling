using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace AirportCarpool.Models {
    public enum LocationTemplate {
        Home,
        Schiphol,
        OtherAddress
    }
    public class NewMovement {
        [DisplayName("From")]
        public LocationTemplate LocationFrom { get; set; }
        
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
        public LocationTemplate LocationTo { get; set; }

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

    }
}