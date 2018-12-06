using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class Flight
    {
        public string icao24 { get; set; }
        public string callsign { get; set; }
        public string origin_country { get; set; }
        public int time_position { get; set; }
        public int last_contact { get; set; }
        public float longitude { get; set; }
        public float latitude { get; set; }
        public float baro_altitude { get; set; }
        public bool on_ground { get; set; }
        public float velocity { get; set; }
        public float true_track { get; set; }
        public float vertical_rate { get; set; }
        public int sensors { get; set; }
        public float geo_altitude { get; set; }
        public string squawk { get; set; }
        public bool spi { get; set; }
        public int position_source { get; set; }
    }

}
