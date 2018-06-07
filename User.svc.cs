using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MLBStyleGuideService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class UserService : IUser
    {
        public List<Sitelet> GetUser(string token)
        {

            List<Sitelet> Sitelets = new List<Sitelet>();

            Sitelets = DAL.SiteletDAL.GetSiteletsByToken(token);

            //var sitelet = new Sitelet();
            //sitelet.description = result;
            //sitelet.id = 1;
            //Sitelets.Add(sitelet);

            //if (token == "1FC4967F-5CC4-4767-AF2C-648918D531EF")
            //{
            //    var sitelet = new Sitelet();
            //    sitelet.description = "Club Marks & Uniforms/Opening Day";
            //    sitelet.id = 1;
            //    Sitelets.Add(sitelet);

            //    sitelet = new Sitelet();
            //    sitelet.description = "Spring Traning";
            //    sitelet.id = 2;
            //    Sitelets.Add(sitelet);
            //}
            return Sitelets;
            //return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
