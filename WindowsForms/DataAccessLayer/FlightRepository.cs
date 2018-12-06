using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace DataAccessLayer
{
    class FlightRepository
    {
        private List<Flight> _flights = new List<Flight>();
        string url = "https://opensky-network.org/api/states/all";

        public FlightRepository()
        {
            string json = CallRestMethod(url);

            JArray jsonObject = JArray.Parse(json);
            foreach (JObject item in jsonObject)
            {
                _flights.Add(new Flight
                {
                    icao24 = (string)item[0],
                    callsign = (string)item[1],
                    origin_country = (string)item[2],
                    time_position = (int)item[3],
                    last_contact = (int)item[4],
                    longitude = (float)item[5],
                    latitude = (float)item[6],
                    baro_altitude = (float)item[7],
                    on_ground = (bool)item[8],
                    velocity = (float)item[9],
                    true_track = (float)item[10],
                    vertical_rate = (float)item[11],
                    sensors = (int)item[12],
                    geo_altitude = (float)item[13],
                    squawk = (string)item[14],
                    spi = (bool)item[15],
                    position_source = (int)item[16]
                });
            }
        }
        
        public static string CallRestMethod(string url)
        {
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "GET";
            webrequest.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
            string result = string.Empty;
            result = responseStream.ReadToEnd();
            webresponse.Close();
            return result;
        }
    }
}
