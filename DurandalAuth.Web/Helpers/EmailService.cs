#region

using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;

#endregion

namespace DurandalAuth.Web.Helpers
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            if (ConfigurationManager.AppSettings["EmailServer"] != "{EmailServer}"
                && ConfigurationManager.AppSettings["EmailUser"] != "{EmailUser}"
                && ConfigurationManager.AppSettings["EmailPassword"] != "{EmailPassword}")
            {
                var mailMsg = new MailMessage();

                // To
                mailMsg.To.Add(new MailAddress(message.Destination, ""));

                // From
                mailMsg.From = new MailAddress("donotreply@onlinehomeservice.com", "Online Service administrator");

                // Subject and multipart/alternative Body
                mailMsg.Subject = message.Subject;
                var html = message.Body;
                mailMsg.AlternateViews.Add(
                    AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                // Init SmtpClient and send
                var smtpClient = new SmtpClient(ConfigurationManager.AppSettings["EmailServer"], Convert.ToInt32(587));
                var credentials = new NetworkCredential(
                    ConfigurationManager.AppSettings["EmailUser"],
                    ConfigurationManager.AppSettings["EmailPassword"]);
                smtpClient.Credentials = credentials;
                smtpClient.EnableSsl = true;

                return Task.Factory.StartNew(() => smtpClient.SendAsync(mailMsg, "token"));
            }
            return Task.FromResult(0);
        }
    }
}