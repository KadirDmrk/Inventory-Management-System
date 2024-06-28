using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_Management_System.Models.Class;


namespace Inventory_Management_System.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        Context c = new Context();
        public ActionResult Index(string p)
        {
            var values = c.Products.Where(x => x.IsActive == true).ToList();


            if (!string.IsNullOrEmpty(p))
            {

                string searchKeyword = p.ToLower();
                values = values.Where(x => x.ProductName.ToLower().Contains(searchKeyword)).ToList(); // Ürün adı araması yap
            }

            return View(values);

        }

        [HttpGet]
        public ActionResult ProductAdd()
        {
            List<SelectListItem> values = (from i in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CategoryName,
                                               Value = i.CategoryID.ToString()
                                           }).ToList();
            ViewBag.prdc = values;



            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Product p1)
        {


            p1.IsActive = true;
            c.Products.Add(p1);
            c.SaveChanges();
            TempData["AlertMessage"] = "Ürün Başarı ile Eklendi.";

            return RedirectToAction("Index");
        }



        public ActionResult ProductDelete(int id)
        {
            var product = c.Products.Find(id);

            if (product != null)
            {
                c.Products.Remove(product);
                c.SaveChanges();
                TempData["AlertMessage"] = "Ürün Başarıyla Silindi...";
            }
            else
            {
                TempData["AlertMessage"] = "Ürün Bulunamadı...";
            }

            return RedirectToAction("Index");
        }
        public ActionResult ProductImport(int id)
        {
            var prdc = c.Products.Find(id);
            return View("ProductImport", prdc);
        }

        public ActionResult ProductUpdate(Product p)
        {
            var prd = c.Products.Find(p.ProductID);
            prd.Categoryid = p.Categoryid;
            prd.ProductName = p.ProductName;
            prd.ProductBrand = p.ProductBrand;
            prd.BillSerialNumber = p.BillSerialNumber;
            prd.CompanyName = p.CompanyName;
            prd.BillDateTime = p.BillDateTime;
            prd.SerialNumber = p.SerialNumber;
            prd.IsActive = true;
            prd.Description = p.Description;
            prd.Stok = p.Stok;
            c.SaveChanges();
            TempData["AlertMessage"] = "Ürun Başarı ile Güncellendi...";
            return RedirectToAction("Index");

        }

        public ActionResult ProductList()
        {
            var values = c.Products.ToList();
            return View(values);
        }


        public ActionResult OutStok(string p)
        {
            var values = c.Products.Where(x => x.IsActive == false).ToList();


            if (!string.IsNullOrEmpty(p))
            {

                string searchKeyword = p.ToLower();
                values = values.Where(x => x.ProductName.ToLower().Contains(searchKeyword)).ToList(); // Ürün adı araması yap
            }

            return View(values);
        }

    }
}