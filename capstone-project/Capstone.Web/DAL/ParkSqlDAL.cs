using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using Capstone.Web.Models;
using System.Data.SqlClient;


namespace Capstone.Web.DAL
{
    public class ParkSqlDAL : IParkDAL
    {
        private readonly string connectionString;
        private const string SQL_GetAllParks = "SELECT * FROM park;";
        private const string SQL_GetParkByCode = "SELECT * FROM park WHERE parkCode = @ParkCode;";

        public ParkSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Park> GetAllParks()
        {
            List<Park> parks = new List<Park>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    parks = conn.Query<Park>(SQL_GetAllParks).ToList();
                    return parks;

                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Park GetPark(string parkCode)
        {
            Park park = new Park();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();


                    park = conn.QueryFirstOrDefault<Park>(SQL_GetParkByCode, new { ParkCode = parkCode });
                    return park;

                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}