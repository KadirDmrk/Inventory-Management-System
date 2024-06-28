using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_Management_System.Models.Class;
using Rotativa;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace Inventory_Management_System.Controllers
{

    public class DepartmentController : Controller
    {
        // GET: Department
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Department.Where(x => x.DepartmentPosition == true).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewDepartment()
        {

            return View();
        }
        [HttpPost]
        public ActionResult NewDepartment(Department d1)
        {
            TempData["AlertMessage"] = "Departman  Başarı ile Eklendi.";
            d1.DepartmentPosition = true;
            c.Department.Add(d1);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmentDelete(int id)
        {
            var department = c.Department.Find(id);

            if (department != null)
            {
                c.Department.Remove(department);
                c.SaveChanges();
                TempData["AlertMessage"] = "Departman Başarıyla Silindi.";
            }
            else
            {
                TempData["AlertMessage"] = "Departman Bulunamadı.";
            }

            return RedirectToAction("Index");
        }
        public ActionResult DepartmentImport(int id)
        {
            var dpt = c.Department.Find(id);
            return View("DepartmentImport", dpt);
        }
        public ActionResult DepartmentUpdate(Department d)
        {
            var dept = c.Department.Find(d.DepartmentID);
            dept.DepartmentName = d.DepartmentName;
            c.SaveChanges();
            TempData["AlertMessage"] = "Departman  Başarı ile Güncellendi.";
            return RedirectToAction("Index");
        }

        public ActionResult DepartmentDetail(int id)
        {
            var values = c.Employees.Where(x => x.Departmentid == id).ToList();
            var dpt = c.Department.Where(x => x.DepartmentID == id).Select(y => y.DepartmentName).FirstOrDefault();//linq sorgusu dashboarda görmek için burda yaptık  
            ViewBag.d = dpt;
            return View(values);
        }

        public ActionResult DepartmentEmployeesDebit(int id)
        {
            var values = c.ProductDebits.Where(x => x.EmployeesID == id).ToList();
            var per = c.Employees.Where(x => x.EmployeeID == id).Select(y => y.EmployeeName + " " + y.EmployeeSurname).FirstOrDefault();
            ViewBag.dpers = per;     
            return View(values);
        }


        public ActionResult PrintEmployeeDebits(int id)
        {
            var mrs = c.Department.Where(x => x.DepartmentPosition == true).ToList();
            var values2 = c.ProductDebits.Where(x => x.EmployeesID == id).ToList();
            var per = c.Employees.Where(x => x.EmployeeID == id).Select(y => y.EmployeeName + " " + y.EmployeeSurname).FirstOrDefault();
            var values = c.Employees.Where(x => x.Departmentid == id).ToList();
            var dpt = c.Department.Where(x => x.DepartmentID == id).Select(y => y.DepartmentName).FirstOrDefault();    
            var ttl = c.Employees.Where(x => x.EmployeeID == id).Select(y => y.EmployessTask).FirstOrDefault(); 
            var dte = c.ProductDebits.Where(x => x.DebitID == id).Select(y => y.Datetime).FirstOrDefault();
            var values3 = c.ProductDebits.Where(x => x.EmployeesID == id).ToList();

            ViewBag.dts = dte;
            ViewBag.dpt = dpt;
            ViewBag.abc = ttl;
            ViewBag.dpers = per;
            ViewBag.EmployeeID = values3;
            return View(values2);

            //return new ViewAsPdf("PrintEmployeeDebits", values)
            //{
            //    FileName = "EmployeeDebits.pdf",
            //    PageSize = Rotativa.Options.Size.A4,
            //    CustomSwitches = "--page-offset 0  --footer-spacing 0 --margin-top 0 --margin-bottom 0 --margin-left 0 --margin-right 0 --zoom 1.2" // Sayfanın tam ortasına yerleştir, CSS yapısını değiştirme
            //};
        }
    }
}