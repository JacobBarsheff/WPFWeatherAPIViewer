using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WpfDataViewer.Models;

namespace WpfDataViewer.DAL
{
    public class APIDataService : IDataService
    {

        static WeatherData GetCurrentWeatherDataCity(string city)
        {
            string url;

            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("http://api.openweathermap.org/data/2.5/weather?");
            sb.Append("&q=" + city);
            sb.Append("&appid=668f986bf179bbac7174d55d13ad1a71");

            url = sb.ToString();

            WeatherData currentWeather = new WeatherData();

            currentWeather = HttpGetCurrentWeatherByLocation(url);

            return currentWeather;
        }
        static WeatherData HttpGetCurrentWeatherByLocation(string url)
        {
            string result = null;

            using (WebClient syncClient = new WebClient())
            {
                result = syncClient.DownloadString(url);
            }

            //Console.WriteLine(result);

            WeatherData currentWeather = JsonConvert.DeserializeObject<WeatherData>(result);

            return currentWeather;
        }


        /// <summary>
        /// read the weather api and load a list of cities
        /// </summary>
        /// <returns>list of characters</returns>
        public List<City> ReadAll()
        {
            //List<WeatherData> cities = new List<WeatherData>();
            List<City> city_weather = new List<City>();
            WeatherData city = new WeatherData();


            List<string> majorUSCites = new List<string> {"New York", "Los Angeles", "Chicago", "Philadelphia", "Phoenix", "Dallas", "San Diego", "Traverse City","Austin","Denver",
            "Seattle","Detroit","Boston","Portland","Oakland","Tulsa","Tampa","Washington"};
            //List<string> majorUSCites = new List<string> {"New York"};

            foreach (string c in majorUSCites)
            {
                city = GetCurrentWeatherDataCity(c);
                City selectedCity = new City();
                selectedCity.Country = city.Sys.Country;
                selectedCity.WeatherDesc = city.Weather[0].Description;
                selectedCity.Lat = city.Coord.Lat;
                selectedCity.Lon = city.Coord.Lon;
                selectedCity.Speed = Math.Round(city.Wind.Speed * 2.2369);
                selectedCity.Temp = Math.Round(ConvertToFahrenheit(city.Main.Temp));
                selectedCity.CloudCoverage = city.Clouds.All;
                selectedCity.Name = city.Name;
                selectedCity.Pressure = city.Main.Pressure;
                selectedCity.Humidity = city.Main.Humidity;
                selectedCity.Deg = city.Wind.Deg;
                selectedCity.Icon = city.Weather[0].Icon;
                city_weather.Add(selectedCity);
            }


            return city_weather;
        }





        static double ConvertToFahrenheit(double degreesKalvin)
        {
            return (degreesKalvin - 273.15) * 1.8 + 32;
        }
    }
}
