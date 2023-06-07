using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Warning
{
    public class GsysFunc
    {
        public static string FncSendMail(string lvMsg, string lvEmail, string lvSubject)
        {
            string lvReturn = "";

            try
            {
                var myMail = new MailMessage();
                myMail.From = new MailAddress("Admin PSSugar<Webmaster@trrgroup.com>");

                myMail.Subject = lvSubject;
                myMail.To.Add(new MailAddress(lvEmail));
                myMail.IsBodyHtml = true;
                myMail.BodyEncoding = System.Text.Encoding.UTF8;
                myMail.Body = lvMsg;

                var smtpClient = new SmtpClient();
                smtpClient.Send(myMail);

                smtpClient.Dispose();
                myMail.Dispose();

                lvReturn = "Success";
            }
            catch (Exception ex)
            {
                lvReturn = ex.Message;
            }

            return lvReturn;
        }
    }
}