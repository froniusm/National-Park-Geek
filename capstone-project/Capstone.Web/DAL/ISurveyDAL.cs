﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public interface ISurveyDAL
    {
        Dictionary<string, int> GetSurveyResults();
        void SaveSurvey(Survey survey);
    }
}