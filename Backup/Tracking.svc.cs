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
            try
            {
                DAL.LicensetrackDAL.SaveDownload(download.token, download.siteletID, download.year, download.file, download.dateDownloaded);
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
