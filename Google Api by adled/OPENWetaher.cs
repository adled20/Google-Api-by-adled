using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google_Api_by_adled
{
    class OPENWetaher
    {
    }
    public class WeatherResponse
    {
        public Location location { get; set; }
        public Current current { get; set; }
    }

    public class Location
    {
        public string name { get; set; }
        public string country { get; set; }
    }

    public class Current
    {
        public float temp_c { get; set; }
        public Condition condition { get; set; }
    }

    public class Condition
    {
        public string text { get; set; }
        public string icon { get; set; }
    }
}
