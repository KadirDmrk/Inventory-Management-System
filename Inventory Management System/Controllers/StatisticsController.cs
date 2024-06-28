using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_Management_System.Models.Class;

namespace Inventory_Management_System.Controllers
{
    public class StatisticsController : Controller
    {
        Context c = new Context();
        // GET: Statistics
        public ActionResult Index()
        {

            var values1 = c.Products.Count().ToString();
            ViewBag.d1 = values1;

            var values2 = c.Employees.Count().ToString();
            ViewBag.d2 = values2;

            var values3 = c.Categories.Count().ToString();
            ViewBag.d3 = values3;

            var values4 = c.Products.Count(p => p.IsActive == true).ToString();
            ViewBag.d4 = values4;

            var values5 = c.Requests.Count().ToString();
            ViewBag.d5 = values5;

            var deger6 = (from x in c.Products select x.ProductBrand).Distinct().Count().ToString(); 
            ViewBag.d6 = deger6;

            var values7 = c.ProductDebits.Count().ToString();
            ViewBag.d7 = values7;

            var values8 = c.Department.Count().ToString();
            ViewBag.d8 = values8;

            return View();
        }
    }
}