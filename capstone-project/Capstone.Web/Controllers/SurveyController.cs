using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DAL;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private readonly ISurveyDAL surveyDAL;
        private readonly IParkDAL parkDAL;

        public SurveyController(ISurveyDAL surveyDAL, IParkDAL parkDAL)
        {
            this.surveyDAL = surveyDAL;
            this.parkDAL = parkDAL;
        }

        // GET: Survey/Survey (new Survey to submit)
        public ActionResult Survey()
        {
            Survey s = new Survey();
            s.ParkCodes = ParkCodes;
            s.SelectActivityLevel = ActivityLevels;
            return View("Survey", s);
        }

        [HttpPost]
        public ActionResult Survey(Survey model)
        {
            // if form is invalid send the user back to the Survey View
            if (!ModelState.IsValid)
            {
                model.ParkCodes = ParkCodes;
                model.SelectActivityLevel = ActivityLevels;
                return View("Survey", model);
            }
            //save Survey model to DB
            surveyDAL.SaveSurvey(model);

            // save in session that they successfully submitted a survey
            TempData["SurveySuccess"] = "Success!  Your survey has been successfully submitted.";

            // redirect to SurveyResults page
            return RedirectToAction("SurveyResults", "Survey");
        }

         // GET /Survey/SurveyResults
         public ActionResult SurveyResults()
         {
            // get all survey results from database
            Dictionary<string, int> results = surveyDAL.GetSurveyResults();

            SurveyResultViewModel srvm = new SurveyResultViewModel()
            {
                SurveyResults = results,
                Parks = parkDAL.GetAllParks(),
            };
            return View("SurveyResults", srvm);
         }

        List<SelectListItem> ParkCodes = new List<SelectListItem>()
        {
            new SelectListItem { Text = "Cuyahoga Valley National Park", Value = "CVNP" },
            new SelectListItem { Text = "Everglades National Park", Value = "ENP" },
            new SelectListItem { Text = "Grand Canyon National Park", Value = "GCNP" },
            new SelectListItem { Text = "Glacier National Park", Value = "GNP"},
            new SelectListItem { Text = "Great Smoky Mountains National Park", Value = "GSMNP" },
            new SelectListItem { Text = "Grand Teton National Park", Value = "GTNP" },
            new SelectListItem { Text = "Mount Rainier National Park", Value = "MRNP" },
            new SelectListItem { Text = "Rocky Mountain National Park", Value = "RMNP" },
            new SelectListItem { Text = "Yellowstone National Park", Value = "YNP" },
            new SelectListItem { Text = "Yosemite National Park", Value = "YNP2" }
        };

        List<SelectListItem> ActivityLevels = new List<SelectListItem>()
        {
            new SelectListItem { Text = "Inactive", Value = "Inactive" },
            new SelectListItem { Text = "Sedentary", Value = "Sedentary" },
            new SelectListItem { Text = "Active", Value = "Active" },
            new SelectListItem { Text = "Extremely Active", Value = "Extremely Active}" }
        };
    }
}