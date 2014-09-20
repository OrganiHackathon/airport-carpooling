using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using AirportCarpool.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AirportCarpool.Services
{
    public class FlightService
    {
        string baseurl = "";

        public FlightService()
        {
            baseurl  = "http://145.35.195.100/rest/flights";
        }

        public List<Flight> SearchFlights(DateTime departure)
        {
            
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            baseurl += "?date=" + departure.Date.ToString("yyyy-MM-dd");
            var response = client.GetAsync(baseurl).Result;
                        
            var resultString = response.Content.ReadAsStringAsync().Result;
            List<Flight> flights = new List<Flight>();

            JObject schipholflights = JObject.Parse(resultString);

            // get JSON result objects into a list
            IList<JToken> results = schipholflights["Flights"]["Flight"].Children().ToList();

            foreach (JToken result in results)
            {
                
                SchipholFlight schipholflight = JsonConvert.DeserializeObject<SchipholFlight>(result.ToString());
                if (schipholflight.ScheduleDate != DateTime.MinValue){

                    Flight flight = new Flight();
                    if (schipholflight.ArrDep == "D")
                    {
                        flight.Departure = schipholflight.ScheduleDate + TimeSpan.Parse(schipholflight.ScheduleTime.ToLongTimeString());
                    }else if (schipholflight.ArrDep == "A"){
                           flight.Arrival = schipholflight.ScheduleDate + TimeSpan.Parse(schipholflight.ScheduleTime.ToLongTimeString());
                    }

                    flight.FlightNumber = schipholflight.FlightNumber;
                    flights.Add(flight);
                }
            }


            return flights;
        }

        //public Flight SearchFlightByFlightNumber(string flightNumber ,string ArrivalDeparture)
        //{
        //    Flight flight = new Flight();

        //    var client = new HttpClient();
        //    if (ArrivalDeparture == "" || flightNumber == "")
        //    {
        //        throw new ArgumentException("necessary parameter is missing");
        //    }
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    baseurl += "/" + ArrivalDeparture + "/" + flightNumber;
        //    var response = client.GetAsync(baseurl).Result;

        //    var resultString = response.Content.ReadAsStringAsync().Result;
        //    List<Flight> flights = new List<Flight>();

        //    JObject schipholflights = JObject.Parse(resultString);

          


        //    List<SchipholFlight> test =  JsonConvert.DeserializeObject<List<SchipholFlight>>(response.ToString());

        //   // List<string> videogames = JsonConvert.DeserializeObject<List<string>>(json);

        //    // get JSON result objects into a list
        //    IList<JToken> results = schipholflights["Flights"].Children().ToList();

        //    //foreach (JToken result in results)
        //    //{
       
        //    // //   SchipholFlight schipholflight = JsonConvert.DeserializeObject<SchipholFlight>(result.ToString());
        //    //    if (schipholflight.ScheduleDate != DateTime.MinValue){
        //    //    if (schipholflight.ArrDep == "D")
        //    //    {
        //    //        flight.Departure = schipholflight.ScheduleDate + TimeSpan.Parse(schipholflight.ScheduleTime.ToLongTimeString());
        //    //    }
        //    //    else if (schipholflight.ArrDep == "A")
        //    //    {
        //    //        flight.Arrival = schipholflight.ScheduleDate + TimeSpan.Parse(schipholflight.ScheduleTime.ToLongTimeString());
        //    //    }
        //    //        }

        //    //    flight.FlightNumber = schipholflight.FlightNumber;
        //    //    return flight;
        //    //}

        //    return null;
            
        //}
    }
}