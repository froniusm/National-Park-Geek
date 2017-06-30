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

            if(Session["IsFahrenheit"] == null)
            {
                Session["IsFahrenheit"] = true; //default temperatures to Fahrenheit
            }

            if(pw.TempIsFahrenheit)
            {
                Session["IsFahrenheit"] = true;
            }

            if(pw.TempIsFahrenheit == false)
            {
                Session["IsFahrenheit"] = false;
            }
            
            return View("Detail", pw);
        }

        [HttpPost]
        public ActionResult Detail(string parkCode, ParkWeatherViewModel pw)
        {
            pw.Park = parkDAL.GetPark(parkCode);
            pw.WeatherForecast = weatherDAL.GetWeatherForPark(parkCode);

            if (pw.TempIsFahrenheit)
            {
                Session["IsFahrenheit"] = true; //default temperatures to Fahrenheit
            }

            if (!pw.TempIsFahrenheit)
            {
                Session["IsFahrenheit"] = false;
            }

            return View("Detail", pw);
        }
    }
}