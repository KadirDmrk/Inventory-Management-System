using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_Management_System.Models.Class;
using Inventory_Management_System.Models.Class.Hardware;
using PagedList;

namespace Inventory_Management_System.Controllers
{

    public class DeviceController : Controller
    {
        Context c = new Context();
        // GET: Device
        public ActionResult Index()
        {
            var values = c.Devices.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult DeviceAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeviceAdd(Devices p)
        {
            c.Devices.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        //GET: /Category/Index
        public ActionResult ModelList(string p, int sayfa = 1)
        {
            var Model = c.Models.ToList();

            if (!string.IsNullOrEmpty(p))
            {

                string searchKeyword = p.ToLower();
                Model = Model.Where(cat => cat.ModelName.ToLower().Contains(searchKeyword)).ToList();
            }


            var pagedModel = Model.ToPagedList(sayfa, 10);


            return View(pagedModel);
        }

        [HttpGet] // İşlem gerçekleşmezse sayfayı yükle 
        public ActionResult ModelAdd()
        {
            TempData["AlertMessage"] = "Model  Başarı ile Eklendi.";
            return View();
        }
        [HttpPost] // Sayfada butona bastığım zaman kaydetme işlemi gerçekleştir. 
        public ActionResult ModelAdd(Model p1)
        {

            if (!ModelState.IsValid)
            {
                return View("ModelAdd");
            }
            c.Models.Add(p1);
            c.SaveChanges();
            return RedirectToAction("ModelList");

        }
        public ActionResult ModelDelete(int id)
        {
            var ctg = c.Models.Find(id);
            c.Models.Remove(ctg);
            c.SaveChanges();
            TempData["AlertMessage"] = "Model Başarı ile Silindi.";
            return RedirectToAction("ModelList");
        }

        public ActionResult ModelImport(int id)
        {
            var ctg = c.Models.Find(id);
            return View("ModelImport", ctg);
        }

        public ActionResult ModelUpdate(Model k)
        {
            var ktgr = c.Models.Find(k.ModelID);
            ktgr.ModelName = k.ModelName;
            c.SaveChanges();
            TempData["AlertMessage"] = "Model Başarı ile Güncellendi.";
            return RedirectToAction("ModelList");
        }



        //GET: /Category/Index
        public ActionResult BrandList(string p, int sayfa = 1)
        {
            var Brand = c.Brands.ToList();

            if (!string.IsNullOrEmpty(p))
            {

                string searchKeyword = p.ToLower();
                Brand = Brand.Where(cat => cat.BrandName.ToLower().Contains(searchKeyword)).ToList();
            }


            var pagedModel = Brand.ToPagedList(sayfa, 10);


            return View(pagedModel);
        }

        [HttpGet] // İşlem gerçekleşmezse sayfayı yükle 
        public ActionResult BrandAdd()
        {
            TempData["AlertMessage"] = "Marka  Başarı ile Eklendi.";
            return View();
        }
        [HttpPost] // Sayfada butona bastığım zaman kaydetme işlemi gerçekleştir. 
        public ActionResult BrandAdd(Brand p1)
        {

            if (!ModelState.IsValid)
            {
                return View("BrandAdd");
            }
            c.Brands.Add(p1);
            c.SaveChanges();
            return RedirectToAction("BrandList");

        }
        public ActionResult BrandDelete(int id)
        {
            var ctg = c.Brands.Find(id);
            c.Brands.Remove(ctg);
            c.SaveChanges();
            TempData["AlertMessage"] = "Marka Başarı ile Silindi.";
            return RedirectToAction("BrandList");
        }

        public ActionResult BrandImport(int id)
        {
            var ctg = c.Brands.Find(id);
            return View("BrandImport", ctg);
        }

        public ActionResult BrandUpdate(Brand k)
        {
            var ktgr = c.Brands.Find(k.BrandID);
            ktgr.BrandName = k.BrandName;
            c.SaveChanges();
            TempData["AlertMessage"] = "Marka Başarı ile Güncellendi.";
            return RedirectToAction("BrandList");
        }




        public ActionResult HardDriveList(string p, int sayfa = 1)
        {
            var hardDrives = c.HardDrives.ToList();

            if (!string.IsNullOrEmpty(p))
            {

                string searchKeyword = p.ToLower();
                hardDrives = hardDrives.Where(cat => cat.HardDriveName.ToLower().Contains(searchKeyword)).ToList();
            }


            var pagedModel = hardDrives.ToPagedList(sayfa, 10);


            return View(pagedModel);
        }

        [HttpGet] // İşlem gerçekleşmezse sayfayı yükle 
        public ActionResult HardDriveAdd()
        {
            TempData["AlertMessage"] = "Başarı ile Eklendi.";
            return View();
        }
        [HttpPost] // Sayfada butona bastığım zaman kaydetme işlemi gerçekleştir. 
        public ActionResult HardDriveAdd(HardDrive p1)
        {

            if (!ModelState.IsValid)
            {
                return View("HardDriveAdd");
            }
            c.HardDrives.Add(p1);
            c.SaveChanges();
            return RedirectToAction("HardDriveList");

        }
        public ActionResult HardDriveDelete(int id)
        {
            var ctg = c.HardDrives.Find(id);
            c.HardDrives.Remove(ctg);
            c.SaveChanges();
            TempData["AlertMessage"] = "İşlem Başarılı !";
            return RedirectToAction("HardDriveList");
        }

        public ActionResult HardDriveImport(int id)
        {
            var ctg = c.HardDrives.Find(id);
            return View("HardDriveImport", ctg);
        }

        public ActionResult HardDriveUpdate(HardDrive k)
        {
            var ktgr = c.HardDrives.Find(k.HardDriveID);
            ktgr.HardDriveName = k.HardDriveName;
            c.SaveChanges();
            TempData["AlertMessage"] = "Harddisk Başarı ile Güncellendi.";
            return RedirectToAction("HardDriveList");
        }





        public ActionResult RamList(string p, int sayfa = 1)
        {
            var Ram = c.Rams.ToList();

            if (!string.IsNullOrEmpty(p))
            {

                string searchKeyword = p.ToLower();
                Ram = Ram.Where(cat => cat.RamName.ToLower().Contains(searchKeyword)).ToList();
            }


            var pagedModel = Ram.ToPagedList(sayfa, 10);


            return View(pagedModel);
        }

        [HttpGet] // İşlem gerçekleşmezse sayfayı yükle 
        public ActionResult RamAdd()
        {
            TempData["AlertMessage"] = "Ram  Eklendi.";
            return View();
        }
        [HttpPost] // Sayfada butona bastığım zaman kaydetme işlemi gerçekleştir. 
        public ActionResult RamAdd(Ram p1)
        {

            if (!ModelState.IsValid)
            {
                return View("RamAdd");
            }
            c.Rams.Add(p1);
            c.SaveChanges();
            return RedirectToAction("RamList");

        }
        public ActionResult RamDelete(int id)
        {
            var ctg = c.Rams.Find(id);
            c.Rams.Remove(ctg);
            c.SaveChanges();
            TempData["AlertMessage"] = "İşlem Başarılı !";
            return RedirectToAction("RamList");
        }

        public ActionResult RamImport(int id)
        {
            var ctg = c.Rams.Find(id);
            return View("RamImport", ctg);
        }

        public ActionResult RamUpdate(Ram k)
        {
            var ktgr = c.Rams.Find(k.RamID);
            ktgr.RamName = k.RamName;
            c.SaveChanges();
            TempData["AlertMessage"] = " Başarı ile Güncellendi.";
            return RedirectToAction("RamList");
        }


        public ActionResult GraphicsCardList(string p, int sayfa = 1)
        {
            var GraphicsCard = c.GraphicsCards.ToList();

            if (!string.IsNullOrEmpty(p))
            {

                string searchKeyword = p.ToLower();
                GraphicsCard = GraphicsCard.Where(cat => cat.GraphicsCardName.ToLower().Contains(searchKeyword)).ToList();
            }


            var pagedModel = GraphicsCard.ToPagedList(sayfa, 10);


            return View(pagedModel);
        }

        [HttpGet] // İşlem gerçekleşmezse sayfayı yükle 
        public ActionResult GraphicsCardAdd()
        {
            TempData["AlertMessage"] = "Ekran Kartı Eklendi.";
            return View();
        }
        [HttpPost] // Sayfada butona bastığım zaman kaydetme işlemi gerçekleştir. 
        public ActionResult GraphicsCardAdd(GraphicsCard p1)
        {

            if (!ModelState.IsValid)
            {
                return View("GraphicsCardAdd");
            }
            c.GraphicsCards.Add(p1);
            c.SaveChanges();
            return RedirectToAction("GraphicsCardList");

        }
        public ActionResult GraphicsCardDelete(int id)
        {
            var ctg = c.GraphicsCards.Find(id);
            c.GraphicsCards.Remove(ctg);
            c.SaveChanges();
            TempData["AlertMessage"] = "İşlem Başarılı !";
            return RedirectToAction("GraphicsCardList");
        }

        public ActionResult GraphicsCardImport(int id)
        {
            var ctg = c.GraphicsCards.Find(id);
            return View("GraphicsCardImport", ctg);
        }

        public ActionResult GraphicsCardUpdate(GraphicsCard k)
        {
            var ktgr = c.GraphicsCards.Find(k.GraphicsCardID);
            ktgr.GraphicsCardName = k.GraphicsCardName;
            c.SaveChanges();
            TempData["AlertMessage"] = " Başarı ile Güncellendi.";
            return RedirectToAction("GraphicsCardList");
        }


        public ActionResult ProcessorList(string p, int sayfa = 1)
        {
            var Processor = c.Processors.ToList();

            if (!string.IsNullOrEmpty(p))
            {

                string searchKeyword = p.ToLower();
                Processor = Processor.Where(cat => cat.ProcessorName.ToLower().Contains(searchKeyword)).ToList();
            }


            var pagedModel = Processor.ToPagedList(sayfa,10);


            return View(pagedModel);
        }

        [HttpGet] // İşlem gerçekleşmezse sayfayı yükle 
        public ActionResult ProcessorAdd()
        {
            TempData["AlertMessage"] = "İşlemci Eklendi.";
            return View();
        }
        [HttpPost] // Sayfada butona bastığım zaman kaydetme işlemi gerçekleştir. 
        public ActionResult ProcessorAdd(Processor p1)
        {

            if (!ModelState.IsValid)
            {
                return View("ProcessorAdd");
            }
            c.Processors.Add(p1);
            c.SaveChanges();
            return RedirectToAction("ProcessorList");

        }
        public ActionResult ProcessorDelete(int id)
        {
            var ctg = c.Processors.Find(id);
            c.Processors.Remove(ctg);
            c.SaveChanges();
            TempData["AlertMessage"] = "İşlem Başarılı !";
            return RedirectToAction("ProcessorList");
        }

        public ActionResult ProcessorImport(int id)
        {
            var ctg = c.Processors.Find(id);
            return View("ProcessorImport", ctg);
        }

        public ActionResult ProcessorUpdate(Processor k)
        {
            var ktgr = c.Processors.Find(k.ProcessorID);
            ktgr.ProcessorName = k.ProcessorName;
            c.SaveChanges();
            TempData["AlertMessage"] = " Başarı ile Güncellendi.";
            return RedirectToAction("ProcessorList");
        }


        public ActionResult MonitorList(string p, int sayfa = 1)
        {
            var Monitor = c.Monitors.ToList();

            if (!string.IsNullOrEmpty(p))
            {

                string searchKeyword = p.ToLower();
                Monitor = Monitor.Where(cat => cat.MonitorName.ToLower().Contains(searchKeyword)).ToList();
            }


            var pagedModel = Monitor.ToPagedList(sayfa, 10);


            return View(pagedModel);
        }

        [HttpGet] // İşlem gerçekleşmezse sayfayı yükle 
        public ActionResult MonitorAdd()
        {
            TempData["AlertMessage"] = "Monitör Eklendi.";
            return View();
        }
        [HttpPost] // Sayfada butona bastığım zaman kaydetme işlemi gerçekleştir. 
        public ActionResult MonitorAdd(Monitor p1)
        {

            if (!ModelState.IsValid)
            {
                return View("MonitorAdd");
            }
            c.Monitors.Add(p1);
            c.SaveChanges();
            return RedirectToAction("MonitorList");

        }
        public ActionResult MonitorDelete(int id)
        {
            var ctg = c.Monitors.Find(id);
            c.Monitors.Remove(ctg);
            c.SaveChanges();
            TempData["AlertMessage"] = "İşlem Başarılı !";
            return RedirectToAction("MonitorList");
        }

        public ActionResult MonitorImport(int id)
        {
            var ctg = c.Monitors.Find(id);
            return View("MonitorImport", ctg);
        }

        public ActionResult MonitorUpdate(Monitor k)
        {
            var ktgr = c.Monitors.Find(k.MonitorID);
            ktgr.MonitorName = k.MonitorName;
            ktgr.SerialNumber = k.SerialNumber;
            c.SaveChanges();
            TempData["AlertMessage"] = " Başarı ile Güncellendi.";
            return RedirectToAction("MonitorList");
        }




    }
}
