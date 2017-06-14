using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WeatherService
{
    [ServiceContract]
    public interface IWeatherService
    {
        [OperationContract]
        City SetCity(string cityName);

        [OperationContract]
        List<WeatherData> GetWeatherForecast();
    }

    [DataContract]
    public class City
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Id { get; set; }
    }

    [DataContract]
    public class WeatherData
    {
        [DataMember]
        public string Weather { get; set; }
        [DataMember]
        public int Temperature { get; set; }

        [DataMember]
        public int Pressure { get; set; }

        [DataMember]
        public int Humidity { get; set; }

        [DataMember]
        public DateTime Date { get; set; }
    }
}
