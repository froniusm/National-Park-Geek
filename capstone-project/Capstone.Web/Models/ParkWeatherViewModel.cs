using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web;
using System.Web.Mvc;

namespace Capstone.Web.Models
{
    public class ParkWeatherViewModel
    {
        public Park Park { get; set; }
        public List<Weather> WeatherForecast { get; set; }
        public bool TempIsFahrenheit { get; set; }

        public string GetAdvisory(Weather w)
        {
            return String.Concat(advisory[w.Forecast] + " " + TempAdvisory(w.High, w.Low));
        }

        private Dictionary<string, string> advisory = new Dictionary<string, string>()
        {
            { "snow", "Be sure to bring some snowshoes!" },
            { "rain", "Pack some rain gear and waterproof shoes." },
            { "thunderstorms", "Seek shelter and avoid hiking on exposed ridges." },
            { "sunny", "Pack sunblock and reapply every two hours." },
            { "cloudy", "Bring a compass and a flashlight, just to be safe." },
            { "partlyCloudy", "Bring along some sunglasses in case you need them." }
        };

        public string TempAdvisory(int highTemp, int lowTemp)
        {
            if(highTemp >= 75)
            {
                return "Bring an extra gallon of water.";
            }
            else if (highTemp - lowTemp >= 20)
            {
                return "Wear breathable layers.";
            }
            else if (lowTemp <= 20)
            {
                return "Exposure to frigid temperatures is dangerous. Be careful.";
            }
            else
            {
                return "";
            }
        }

        // gives back an integer of the current temperature in degrees Celsius
        public int TempInCelsius(int temp)
        {
            int celsius = Convert.ToInt32((temp - 32) / 1.8);
            return celsius;
        }
    }
}