using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace WeatherService
{
    class WeatherAPI
    {
        private static string CallRestService(string uri)
        {

            var req = HttpWebRequest.Create(uri);
            req.Method = "GET";
            req.ContentType = "application/json";

            using (var resp = req.GetResponse())
            {
                return new StreamReader(resp.GetResponseStream()).ReadToEnd();
            }

            return null;
        }

        public static City GetCityIdByName(string cityName)
        {
            JArray res = JArray.Parse(CallRestService("https://www.metaweather.com/api/location/search/?query=" + cityName));
            if (res.HasValues)
            {
                return new City()
                {
                    Id = (int)res.First["woeid"],
                    Name = (string)res.First["title"]
                };
            }
            return null;
        }

        public static List<WeatherData> GetWeatherForecast(City city)
        {
            JObject res = JObject.Parse(CallRestService("https://www.metaweather.com/api/location/" + city.Id.ToString()));
            var weather = ((JArray)res["consolidated_weather"]).ToList();

            return weather.Select(x => new WeatherData
            {
                Weather = (string)x["weather_state_name"],
                Temperature = (int)x["the_temp"],
                Pressure = (int)x["air_pressure"],
                Humidity = (int)x["humidity"],
                Date = DateTime.Parse((string)x["applicable_date"])
            }).ToList();
        }
    }
}