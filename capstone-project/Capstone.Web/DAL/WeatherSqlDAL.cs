using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;
using Dapper;

namespace Capstone.Web.DAL
{
    public class WeatherSqlDAL : IWeatherDAL
    {
        private readonly string connectionString;
        private const string SQL_GetWeatherForPark = "SELECT * FROM weather WHERE parkCode = @parkCode;";

        public WeatherSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Weather> GetWeatherForPark(string parkCode)
        {
            List<Weather> weather = new List<Weather>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    weather = conn.Query<Weather>(SQL_GetWeatherForPark, new { parkCode = parkCode }).ToList();

                    // format weather.Forecast to compatible name of /content/weather/*.png images
                    foreach (Weather w in weather)
                    {
                        if(w.Forecast == "partly cloudy")
                        {
                            w.Forecast = "partlyCloudy";
                        }
                    }

                    return weather;

                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}