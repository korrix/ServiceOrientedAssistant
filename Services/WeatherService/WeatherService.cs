using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WeatherService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class WeatherService : IWeatherService
    {
        private City currentCity = null;
        public City SetCity(string cityName)
        {
            currentCity = WeatherAPI.GetCityIdByName(cityName);
            return currentCity;
        }

        public List<WeatherData> GetWeatherForecast()
        {
            if (currentCity == null) return null;
            return WeatherAPI.GetWeatherForecast(currentCity);
        }
    }
}
