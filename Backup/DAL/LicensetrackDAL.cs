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
    public class LicensetrackDAL
    {
        public static void SaveDownload(string token, int siteletID, string year, string file, string dateDownloaded)
        {

            SqlConnection conn = null;
            SqlCommand command = null;
            try
            {
                // create and open a connection object
                using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MLBStyleGuideConnectionString1"].ConnectionString))
                {
                    conn.Open();
                    using (command = new SqlCommand("[mlbstyleguide].[uspSaveDownload]", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@Token", SqlDbType.UniqueIdentifier).Value = new Guid(token);
                        command.Parameters.AddWithValue("@Section", GetSectionNameBySiteletID(siteletID));
                        command.Parameters.AddWithValue("@Year", year);
                        command.Parameters.AddWithValue("@File", file);
                        command.Parameters.AddWithValue("@DateDownloaded", Convert.ToDateTime(dateDownloaded));
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorEmailer.SendEmail(ex);
                throw ex;
            }
            finally
            {
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
        }

        private static string GetSectionNameBySiteletID(int siteletID)
        {
            string sectionName = string.Empty;

            switch (siteletID)
            {
                case 2:
                    sectionName = "spring";
                    break;
                case 3:
                    sectionName = "alls";
                    break;
                case 4:
                    sectionName = "world";
                    break;
                case 5:
                    sectionName = "coop";
                    break;
                case 6:
                    sectionName = "mascot";
                    break;
                case 7:
                    sectionName = "minor";
                    break;
                case 8:
                    sectionName = "trend";
                    break;
                case 9://No Tracking on Design Service
                    break;
                case 10:
                    sectionName = "marketing";
                    break;
                case 11:
                    sectionName = "restricted";
                    break;
            }

            return sectionName;
        }
    }
}