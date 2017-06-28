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
    }
}