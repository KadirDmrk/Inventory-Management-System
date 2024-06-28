using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_Management_System.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult PageError()
        {
            Response.TrySkipIisCustomErrors = true;
            return View("PageError");
        }
         public ActionResult Pag403()
        {
            Response.StatusCode = 403;
            Response.TrySkipIisCustomErrors = true;
            return View("PageError");
        }
        public ActionResult Page404()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View("PageError");
        }
    }
}