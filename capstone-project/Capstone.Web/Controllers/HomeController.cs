using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DAL;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IParkDAL parkDAL;
        private readonly IWeatherDAL weatherDAL;
        private string TemperatureGuage;

        public HomeController(IParkDAL parkDAL, IWeatherDAL weatherDAL)
        {
            this.parkDAL = parkDAL;
            this.weatherDAL = weatherDAL;
        }

        // GET: Home
        public ActionResult Index()
        {
            var parks = parkDAL.GetAllParks();
            return View("Index", parks);
        }

        // Detail 
        public ActionResult Detail(string parkCode)
        {
            var park = parkDAL.GetPark(parkCode);
            ParkWeatherViewModel pw = new ParkWeatherViewModel();

            pw.Park = park;
            pw.WeatherForecast = weatherDAL.GetWeatherForPark(parkCode);

            if(Session[TemperatureGuage] == null)
            {
                Session[TemperatureGuage] = "F"; //default temperatures to Fahrenheit
                pw.TempInFahrenheitOrCelsius = (string)Session[TemperatureGuage];
            }

            if(pw.TempInFahrenheitOrCelsius == "C")
            {
                Session[TemperatureGuage] = "C";
            }
            
            return View("Detail", pw);
        }

        [HttpPost]
        public ActionResult Detail(string parkCode, string tempGuage)
        {
            var park = parkDAL.GetPark(parkCode);
            ParkWeatherViewModel pw = new ParkWeatherViewModel();

            pw.Park = park;
            pw.WeatherForecast = weatherDAL.GetWeatherForPark(parkCode);

            if (pw.TempInFahrenheitOrCelsius == "F")
            {
                Session[TemperatureGuage] = "F"; //default temperatures to Fahrenheit
                pw.TempInFahrenheitOrCelsius = (string)Session[TemperatureGuage];
            }

            if (pw.TempInFahrenheitOrCelsius == "C")
            {
                Session[TemperatureGuage] = "C";
            }

            return View("Detail", pw);
        }
    }
}