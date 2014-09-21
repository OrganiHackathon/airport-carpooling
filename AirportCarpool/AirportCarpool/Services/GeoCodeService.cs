using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace AirportCarpool.Services
{
    public class GeoCodeService
    {
        private const string ApiKey = "cnjzskcgdmzd25xkq6eudpqc";
        private const string BaseUrl = "https://api.tomtom.com/lbs/services/geocode/4/geocode";

        public GeoCodeService() { }

        public string AdressToGeoCode(string street, string streetNr, string postCode, string country){

            //https://api.tomtom.com/lbs/services/geocode/4/geocode?ST=32&T=bosduifstraat&PC=2018&CN=belgium&key=cnjzskcgdmzd25xkq6eudpqc
            string geoCode = string.Empty;
            string reqUrl = string.Format("({0}?ST={1}&T={2}&PC={3}&CN={4}&key={5}", BaseUrl, HttpUtility.UrlEncode(streetNr), HttpUtility.UrlEncode(street), HttpUtility.UrlEncode(postCode), HttpUtility.UrlEncode(country));
            HttpClient client = new HttpClient();
            
            return geoCode;
        }
    }
}