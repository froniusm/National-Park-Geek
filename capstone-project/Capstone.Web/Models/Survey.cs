using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Models
{
    public class Survey
    {
        public int? SurveyId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string ParkCode { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("EmailAddress",
            ErrorMessage = "The email addresses do not match")]
        public string ConfirmEmailAddress { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string ActivityLevel { get; set; }

        public List<SelectListItem> ParkCodes { get; set; } 

        public List<SelectListItem> SelectActivityLevel { get; set; } 
    }
}