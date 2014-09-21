using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Xml;
using AirportCarpool.Models;

namespace AirportCarpool.Services
{
    public class TomTomService
    {

        public void GetDistance(Location locationA, Location locationB)
        {
            var client = new HttpClient();
            string baseurl = "https://api.tomtom.com/lbs/services/route/3/";
            string apiCode = "/Quickest/xml?key=cnjzskcgdmzd25xkq6eudpqc";
            string url = baseurl + locationA.Geolocation + ":" + locationB.Geolocation + apiCode;
            string totalDistanceMeters;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;         

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(response.GetResponseStream());

            //*[local-name()="summary"]
            XmlNode node = xmlDoc.SelectSingleNode("//*[local-name()='totalDistanceMeters']");
            if (node != null)
                totalDistanceMeters = node.InnerText;
            /*totalDistanceMeters*/
                        
        }
    }
}