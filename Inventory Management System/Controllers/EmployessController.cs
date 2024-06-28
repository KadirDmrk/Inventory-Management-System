using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_Management_System.Models.Class;
using PagedList;
using PagedList.Mvc;


namespace Inventory_Management_System.Controllers
{
    public class EmployessController : Controller
    {
        // GET: Employess
        Context c = new Context();
        public ActionResult Index(string p)
        {
            //var values = c.Employees.Where(x => x.IsActive == true).ToList();
            var values = c.Employees.ToList();

            if (!string.IsNullOrEmpty(p))
            {
                // Arama terimini kullanarak personel adı ve/veya departman adı üzerinde filtreleme yap
                values = values.Where(emp => emp.EmployeeName.ToLower().Contains(p.ToLower()) ||
                                                    emp.Department.DepartmentName.ToLower().Contains(p.ToLower()))
                                                    .ToList();
            }

            return View(values);
        }

        [HttpGet]
        public ActionResult NewEmployess()
        {


            List<SelectListItem> values = (from i in c.Department.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.DepartmentName,
                                               Value = i.DepartmentID.ToString()
                                           }).ToList();
            ViewBag.prdc = values;
            return View();

        }
        [HttpPost]
        public ActionResult NewEmployess(Employees e1)
        {
            TempData["AlertMessage"] = "Personel  Başarı ile Eklendi.";
            if (!ModelState.IsValid)
            {
                return View("NewEmployess");
            }
            c.Employees.Add(e1);
            //e1.IsActive = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EmployessImport(int id)
        {
            List<SelectListItem> values = (from i in c.Department.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.DepartmentName,
                                               Value = i.DepartmentID.ToString()
                                           }).ToList();
            ViewBag.prdc = values;
            var emp = c.Employees.Find(id);
            return View("EmployessImport", emp);
        }

        public ActionResult EmployessUpdate(Employees k)
        {
            var emp = c.Employees.Find(k.EmployeeID);
            emp.EmployessTask = k.EmployessTask;
            emp.EmployeeName = k.EmployeeName;
            emp.EmployeeSurname = k.EmployeeSurname;
            emp.EmployeeMail = k.EmployeeMail;
            emp.Departmentid = k.Departmentid;
            c.SaveChanges();
            TempData["AlertMessage"] = "Personel  Başarı ile Güncellendi.";
            return RedirectToAction("Index");
        }
        public ActionResult EmployessDelete(int id)
        {
            var ktg = c.Employees.Find(id);
            c.Employees.Remove(ktg);
            c.SaveChanges(); // kaydet 
            return RedirectToAction("Index"); // aksiyona yönlendir 
        }
    }

}