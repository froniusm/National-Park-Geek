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
        private const string SQL_GetSurveys = "SELECT COUNT(*) as votes, parkCode FROM survey_result GROUP BY parkCode ORDER BY votes DESC, parkCode;";
        private const string SQL_SaveSurvey = "INSERT INTO survey_result VALUES (@parkCode, @emailAddress, @state, @activityLevel)";

        public SurveySqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Dictionary<string, int> GetSurveyResults()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    Dictionary<string, int> output = conn.Query(SQL_GetSurveys).ToDictionary(
                        row => (string)row.parkCode,
                        row => (int)row.votes);
                    return output;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void SaveSurvey(Survey survey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    survey.SurveyId = conn.Query<int>(SQL_SaveSurvey, new
                    {
                        parkCode = survey.ParkCode,
                        emailAddress = survey.EmailAddress,
                        state = survey.State,
                        activityLevel = survey.ActivityLevel
                       
                    }).First();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}