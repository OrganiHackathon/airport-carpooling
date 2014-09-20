using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Mvc;
using AirportCarpool.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AirportCarpool.Controllers
{
    public class SchipholFlightController : Controller
    {        
        public ActionResult Index()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync("http://145.35.195.100/rest/flights").Result;
          
            
            var resultString = response.Content.ReadAsStringAsync().Result;
            List<SchipholFlight> flights = new List<SchipholFlight>();
         
            JObject flights_ = JObject.Parse(resultString);

            // get JSON result objects into a list
            IList<JToken> results = flights_["Flights"]["Flight"].Children().ToList();

            foreach (JToken result in results)
            {
                SchipholFlight flight = JsonConvert.DeserializeObject<SchipholFlight>(result.ToString());
                flights.Add(flight);
            }

             //(List<SchipholFlight>)Newtonsoft.Json.JsonConvert.DeserializeObject(Request["jsonString"], typeof(List<test>));
            return View(flights);
        }

        // GET api/schipholflight/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/schipholflight
        public void Post([FromBody]string value)
        {
        }

        // PUT api/schipholflight/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/schipholflight/5
        public void Delete(int id)
        {
        }
    }
}
