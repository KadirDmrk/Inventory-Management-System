using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Net;

namespace Inventory_Management_System.Models
{
    public class EmailService
    {
        public async Task SendEmailAsync(string to, string subject, string body)
        {
            using (var message = new MailMessage())
            {
                message.To.Add(new MailAddress(to));
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true; // HTML formatında mail göndermek isterseniz

                using (var client = new SmtpClient("mail.bbnairlines.com.tr"))
                {
                    client.Port = 587; // SMTP portu
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("kadir.demirkaya@bbnairlines.com.tr", "fR@%K~bNs7u1Gn9c");
                    client.EnableSsl = true; // SSL/TLS kullanıyorsanız true yapın

                    await client.SendMailAsync(message);
                }
            }
        }

    }
}