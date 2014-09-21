using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportCarpool.Models
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string GSM { get; set; }

        public int LocationId { get; set; }
        public string Street { get; set; }
        public string StreetNr { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Geolocation { get; set; }
    }
}