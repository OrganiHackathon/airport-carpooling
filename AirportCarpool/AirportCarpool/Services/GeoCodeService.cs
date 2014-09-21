using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Xml;

namespace AirportCarpool.Services
{
    public class GeoCodeService
    {
        private const string ApiKey = "cnjzskcgdmzd25xkq6eudpqc";
        private const string BaseUrl = "https://api.tomtom.com/lbs/services/geocode/4/geocode";

        public GeoCodeService() { }

        public string AdressToGeoCode(string street, string streetNr, string postCode, string country){

            //vb https://api.tomtom.com/lbs/services/geocode/4/geocode?ST=32&T=bosduifstraat&PC=2018&CN=belgium&key=cnjzskcgdmzd25xkq6eudpqc
            string geoCode = string.Empty;
            try
            {
                string reqUrl = string.Format("{0}?ST={1}&T={2}&PC={3}&CN={4}&key={5}", BaseUrl, HttpUtility.UrlEncode(streetNr), HttpUtility.UrlEncode(street), HttpUtility.UrlEncode(postCode), HttpUtility.UrlEncode(country), ApiKey);
                HttpClient client = new HttpClient();
                System.Net.HttpWebRequest request = WebRequest.Create(reqUrl) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;


                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());

                //*[local-name()="summary"]
                XmlNodeList nodeList = xmlDoc.SelectNodes("//*[local-name()='geoResult']");
                if (nodeList.Count > 0)
                {
                    geoCode = string.Format("{0}:{1}", nodeList.Item(0).SelectSingleNode("*[local-name()='latitude']").InnerText, nodeList.Item(0).SelectSingleNode("*[local-name()='longitude']").InnerText);
                }
            }
            catch (Exception) { }
            return geoCode;
        }
    }
}