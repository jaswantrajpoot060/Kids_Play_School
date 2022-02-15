using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace  BusinessObject
{
    public class ConstantEmail : BaseObject
    {

        public static void SendMail(string mailto, string from, string Subject, string body)
        {

            string mailbody = body;
            MailAddress MailFrom = new MailAddress(from, "Indian play School");
            MailAddress MailTo = new MailAddress(mailto, "");
            MailMessage mailmessage = new MailMessage(MailFrom, MailTo);

            mailmessage.To.Add(mailto);
            mailmessage.Subject = Subject;
            mailmessage.Body = body;
            mailmessage.ReplyTo = new MailAddress(from);
            mailmessage.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = true;
            client.Host = "smtp.gmail.com";

            client.Credentials = new NetworkCredential("Jaswantrajpoot060@gmail.com", "@jassi3583");

            //Add this line to bypass the certificate validation
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s,
            System.Security.Cryptography.X509Certificates.X509Certificate certificate,
            System.Security.Cryptography.X509Certificates.X509Chain chain,
            System.Net.Security.SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };
            client.Send(mailmessage);

        }
    }
}
