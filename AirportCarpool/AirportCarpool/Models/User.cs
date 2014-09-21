using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AirportCarpool.Models {
    
    [Table("Users")]
    public class User {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string GSM { get; set; }
        public virtual Location Location { get; set; }

        public UserViewModel ViewModel() {
            UserViewModel vm = new UserViewModel();

            vm.UserId = UserId;
            vm.UserName = UserName;
            vm.Email = Email;
            vm.Name = Name;
            vm.SurName = SurName;
            vm.GSM = GSM;
            vm.LocationId = Location.LocationId;
            vm.Street = Location.Street;
            vm.StreetNr = Location.StreetNr;
            vm.PostalCode = Location.PostalCode;
            vm.City = Location.City;
            vm.Country = Location.Country;
            vm.Geolocation = Location.Geolocation;

            return vm;
        }
        public void FillFromViewModel(UserViewModel vm) {
            UserId = vm.UserId;
            UserName = vm.UserName;
            Email = vm.Email;
            Name = vm.Name;
            SurName = vm.SurName;
            GSM = vm.GSM;
            Location.LocationId = vm.LocationId;
            Location.Street = vm.Street;
            Location.StreetNr = vm.StreetNr;
            Location.PostalCode = vm.PostalCode;
            Location.City = vm.City;
            Location.Country = vm.Country;
            Location.Geolocation = vm.Geolocation;
        }
    }

    



}