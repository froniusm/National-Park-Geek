using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.Models;

namespace Capstone.Web.Models
{
    public class SurveyResultViewModel
    {
        public Dictionary<string, int> SurveyResults { get; set; }
        public List<Park> Parks { get; set; }
    }
}