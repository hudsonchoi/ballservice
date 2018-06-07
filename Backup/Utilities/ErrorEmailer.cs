using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MLBStyleGuideService.Utilities
{
    public static class ErrorEmailer
    {
        public static void SendEmail(Exception ex)
        {
            try
            {
                System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient();
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                System.Net.Mail.MailAddress fromAddress = new System.Net.Mail.MailAddress("info@mlbstyleguide.com", "Debugger");
                smtpClient.Host = System.Configuration.ConfigurationManager.AppSettings["SMTPServer"].ToString();
                smtpClient.Port = 25;
                message.From = fromAddress;
                message.To.Add("hudsonchoi@gmail.com");
                message.Subject = "MLBStyleGuide : Error on the DALs of REST Services";
                //message.Body = Server.GetLastError().InnerException.Message.ToString();
                message.Body = ex.Message;
                smtpClient.Send(message);
            }
            catch (Exception e)
            {
                //lblStatus.Text = "Send Email Failed." + ex.Message;
            }
        }
    }
}