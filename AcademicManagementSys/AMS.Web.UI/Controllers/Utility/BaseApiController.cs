using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Mail;
namespace AMS.Web.UI.Controllers
{
    public class BaseApiController : ApiController
    {
        public BaseApiController()
        { 
            //constructor
        }

        // Encode function
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        // Decode function
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public bool SendEmail(string To, string Subject, string Body, string FromUserID, string FromUserPassword)
        {
            try
            {
                using (MailMessage mm = new MailMessage(FromUserID, To))
                {
                    mm.Subject = Subject;
                    mm.Body = Body;
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(FromUserID, FromUserPassword);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                    return true;
                }

            }
            catch
            {
                return false;
            }
        }
    }
}
