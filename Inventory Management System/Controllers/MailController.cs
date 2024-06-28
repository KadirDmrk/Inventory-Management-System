using Inventory_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using System.Net.Mail;
using System.Threading.Tasks;
using MailKit.Security;
using System.Text;
using System.Configuration;
using SmtpClient = System.Net.Mail.SmtpClient;
using System.Net;

namespace Inventory_Management_System.Controllers
{
    public class MailController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(SMTP model)
        {
            if (ModelState.IsValid)
            {
                var smtpClient = new SmtpClient
                {
                    Host = System.Configuration.ConfigurationManager.AppSettings["emailHost"],
                    Port = int.Parse(System.Configuration.ConfigurationManager.AppSettings["emailPort"]),
                    EnableSsl = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["EnableSsl"]),
                    Credentials = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["emailAccount"], System.Configuration.ConfigurationManager.AppSettings["emailPassword"])

                };

                using (var message = new MailMessage())
                {
                    
                    message.From = new MailAddress("kadir.demirkaya@bbnairlines.com.tr");

                   
                    message.To.Add(new MailAddress(model.Email));

                    message.Subject = model.Subject;
                    message.Body = $"Gönderen: {model.Name} ({model.Email})\n\nMesaj:\n{model.Message}";

                    smtpClient.Send(message);
                }
                TempData["AlertMessage"] = "E postanız   Başarı ile Gönderildi.";
                return RedirectToAction("Index");
            }

            return View(model);
        }




    }
}