using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDataViewer.Models
{
    public class City
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public string WeatherDesc { get; set; }
        public double Temp { get; set; }
        public double Speed { get; set; }
        public int CloudCoverage { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
        public double Deg { get; set; }
        public string Icon { get; set; }
    }
}
