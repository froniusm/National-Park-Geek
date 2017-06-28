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

        public HomeController(IParkDAL parkDAL)
        {
            this.parkDAL = parkDAL;
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
            return View("Detail", park);
        }
    }
}