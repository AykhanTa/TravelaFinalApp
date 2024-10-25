using System.Net.Mail;
using System.Net;
using TravelaFinalApp.Application.Interfaces;

namespace TravelaFinalApp.Persistence.Implementations
{
    public class EmailService : IEmailService
    {
        public void SendEmail(List<string> emails, string subject, string body)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("aykhanft@code.edu.az", "Travela");

            foreach (var email in emails)
            {
                mailMessage.To.Add(email);
            }

            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;


            mailMessage.Body = body;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("aykhanft@code.edu.az", "ggjj ofak legg wlyz");

            smtpClient.Send(mailMessage);
        }
    }
}
