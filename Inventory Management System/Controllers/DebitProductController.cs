using Inventory_Management_System.Models.Class;
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace Inventory_Management_System.Controllers
{
    public class DebitProductController : Controller
    {
        Context c = new Context();

        public ActionResult Index()
        {
            var paymentTypes = c.Employees.ToList();
            ViewBag.EmployeeList = new SelectList(paymentTypes, "EmployeeID", "EmployeeName", null);
            return View();
        }

        public ActionResult SearchBySerialNumber(string serialNumber)
        {
            var products = c.Products.Where(p => p.SerialNumber == serialNumber).ToList();
            var paymentTypes = c.Employees.ToList();
            ViewBag.EmployeeList = new SelectList(paymentTypes, "EmployeeID", "EmployeeName", null);

            return View(products);
        }

        public ActionResult Listing(string p)
        {
            var values = c.ProductDebits.ToList();
            return View(values);
        }

        [HttpPost]
        public ActionResult Debit(int productId, int employeeId)
        {
            var product = c.Products.FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                var productDebit = new ProductDebit
                {
                    Datetime = DateTime.Now,
                    Piece = 1,
                    ProductID = product.ProductID,
                    CategoryID = product.Categoryid,
                    DebitProductBrand = product.ProductBrand,
                    DebitProductSerialNumber = product.SerialNumber,
                    Description = product.Description,
                    IsActive = product.IsActive,
                    EmployeesID = employeeId
                };

                c.ProductDebits.Add(productDebit);
                c.SaveChanges();

                ViewBag.Message = "Ürün zimmetlendi.";
            }
            else
            {
                ViewBag.Message = "Ürün bulunamadı.";
            }

            return RedirectToAction("Listing");
        }

        [HttpPost]
        public ActionResult ReturnEmbezzlement()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ReturnEmbezzlement(string p)
        {
            var values = c.Employees.ToList();

            if (!string.IsNullOrEmpty(p))
            {
                string searchKeyword = p.ToLower();
                values = values.Where(x =>
                    (x.EmployeeName + " " + x.EmployeeSurname).ToLower().Contains(searchKeyword)).ToList();
            }

            return View(values);
        }

        [HttpGet]
        public ActionResult ReturnEmbezzlementDelete(int id)
        {
            var productDebit = c.ProductDebits.FirstOrDefault(x => x.DebitID == id);

            if (productDebit == null)
            {
                ViewBag.ErrorMessage = "Ürün bulunamadı.";
                return View("PageError");
            }

            c.ProductDebits.Remove(productDebit);
            c.SaveChanges();

            return RedirectToAction("ReturnEmbezzlement");
        }

        public ActionResult DepartmentEmployeesDebit(int id)
        {
            var values = c.ProductDebits.Where(x => x.EmployeesID == id).ToList();
            var per = c.Employees.Where(x => x.EmployeeID == id).Select(y => y.EmployeeName + " " + y.EmployeeSurname).FirstOrDefault();
            ViewBag.dpers = per;
            ViewBag.employeeId = id; 
            return View(values);
        }

        
        
        

    }
}
