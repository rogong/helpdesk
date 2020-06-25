using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CallogApp.Utility.Mail
{
    public static class RequestEmailService 
    {

       

        public static void Send(string userEmail,  string content, string receiver, string subject)
        {
            //instantiate a new MimeMessage
            var message = new MimeMessage();
            //setting To e-mail address
            message.To.Add(new MailboxAddress(receiver, userEmail));

            //setting From e-mail address
            message.From.Add(new MailboxAddress("Superflux IT Portal", "it@superfluxnigeria.com"));
            //Subject
            message.Subject = subject;
            // E-mail message  body
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = content
            };

            //Configure the e-mail
            using (var emailClient = new SmtpClient())
            {
                emailClient.Connect("smtp.superfluxnigeria.com", 587, false);

                emailClient.Authenticate("oluseyi_ayinde@superfluxnigeria.com", "SpAyinde_@19");
                emailClient.Send(message);
                emailClient.Disconnect(true);

            }
        }
    }
}
