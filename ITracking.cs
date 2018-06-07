using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace MLBStyleGuideService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITracking" in both code and config file together.
    [ServiceContract]
    public interface ITracking
    {
        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "save_download", 
            ResponseFormat=WebMessageFormat.Json, 
            RequestFormat=WebMessageFormat.Json)]
        string SaveDownload(Download person);

        [OperationContract]
        void DoWork();
    }

    [DataContract]
    public class Download
    {
        [DataMember]
        public string token { get; set; }
        [DataMember]
        public int siteletID { get; set; }
        [DataMember]
        public string year { get; set; }
        [DataMember]
        public string file { get; set; }
        [DataMember]
        public string dateDownloaded { get; set; }
        [DataMember]
        public string username { get; set; }
        [DataMember]
        public string ip { get; set; }

    }
}
