using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class SurveySqlDAL : ISurveyDAL
    {
        private readonly string connectionString;
        private const string SQL_GetSurveys = "SELECT COUNT(*) as votes FROM survey_result GROUP BY parkCode, ORDER BY votes;";
        private const string SQL_SaveSurvey = "INSERT INTO survey_result VALUES (@parkCode, @emailAddress, @state, @activityLevel)";

        public SurveySqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Survey> GetAllSurveys()
        {
            throw new NotImplementedException();
        }

        public void SaveSurvey()
        {
            throw new NotImplementedException();
        }
    }
}