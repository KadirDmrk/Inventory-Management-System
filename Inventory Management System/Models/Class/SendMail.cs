using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Configuration;

public class SendMail
{
    private readonly string emailHost = ConfigurationManager.AppSettings["emailHost"];
    private readonly int emailPort = int.Parse(ConfigurationManager.AppSettings["emailPort"]);
    private readonly string emailAccount = ConfigurationManager.AppSettings["emailAccount"];
    private readonly string emailPassword = ConfigurationManager.AppSettings["emailPassword"];
    private readonly bool enableSsl = bool.Parse(ConfigurationManager.AppSettings["EnableSsl"]);

    public async Task SendEmailAsync(string to, string subject, string body)
    {
        try
        {
            using (var smtpClient = new SmtpClient(emailHost, emailPort))
            {
                smtpClient.EnableSsl = enableSsl;
                smtpClient.Credentials = new NetworkCredential(emailAccount, emailPassword);

                using (var message = new MailMessage(emailAccount, to))
                {
                    message.Subject = subject;
                    message.Body = body;
                    message.IsBodyHtml = true;

                    await smtpClient.SendMailAsync(message);
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("E-posta gönderirken bir hata oluştu: " + ex.Message);
        }
    }
}
