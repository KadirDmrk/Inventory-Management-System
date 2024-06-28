using Inventory_Management_System.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Inventory_Management_System.Controllers
{
    //[AllowAnonymous]
    public class LoginController : Controller
    {
        Context c = new Context();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            //var user = c.Admins.FirstOrDefault(x =>string.Equals(x.Username, p.Username, StringComparison.Ordinal) && x.Password == p.Password);
            var username = p.Username.ToUpper();
            var values = c.Admins.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);
            //var values = c.Admins.FirstOrDefault(x => x.Username.Equals(p.Username, StringComparison.OrdinalIgnoreCase) && x.Password == p.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Username, false);
                Session["Username"] = values.Username.ToString();
                return RedirectToAction("Index", "Statistics");
            }
            else
            {
                TempData["AlertMessage"] = "Kullanıcı Hatalı veya Geçersiz Şifre";
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

    }
}