using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using MLBStyleGuideService.Utilities;

namespace MLBStyleGuideService.DAL
{
    public static class SiteletDAL
    {
        public static List<Sitelet> GetSiteletsByToken(string token)
        {

            SqlConnection conn = null;
            SqlCommand command = null;
            SqlDataReader reader = null;
            List<string> clients = new List<string>();
            string result = string.Empty;
            List<Sitelet> Sitelets = new List<Sitelet>();
            try
            {
                // create and open a connection object
                using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MLBStyleGuideConnectionString1"].ConnectionString))
                {
                    conn.Open();
                    using (command = new SqlCommand("[mlbstyleguide].[uspGetSiteletsByToken]", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@token", SqlDbType.UniqueIdentifier).Value = new Guid(token);
                        reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                        while (reader.Read())
                        {
                            var sitelet = new Sitelet();
                            sitelet.id = Convert.ToInt32(reader[0].ToString());
                            sitelet.description = reader[1].ToString();
                            Sitelets.Add(sitelet);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorEmailer.SendEmail(ex);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
                if (command != null)
                {
                    command.Dispose();
                }

                if (conn != null)
                {
                    conn.Close();
                }
            }
            //return clients;
            return Sitelets;
        }
    }
}