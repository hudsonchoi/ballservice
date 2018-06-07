using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MLBStyleGuideService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Tracking" in code, svc and config file together.
    public class Tracking : ITracking
    {
        
        public void DoWork()
        {
        }

        public string SaveDownload(Download download)
        {
            if ((download.token == null)||(download.token == ""))
            {
                download.token = "{229D61EB-EADF-4CB4-ABE5-001DB2EB4E08}";
            }
            if (download.username == null)
            {
                download.username = "";
            }
            if (download.ip == null)
            {
                download.ip = "";
            }


            try
            {
                DAL.LicensetrackDAL.SaveDownload(download.token, download.siteletID, download.year, download.file, download.dateDownloaded, download.username, download.ip);
                return "1";
            }
            catch (Exception ex)
            {
                return "0";
            }
            //throw new NotImplementedException();
        }
    }
}
