using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_Management_System.Models.Class;

namespace Inventory_Management_System.Controllers
{
    public class PersonelTalepController : Controller
    {
         Context db = new Context(); // DbContext sınıfınızın adıyla değiştirilmelidir.

        // Personel talep formu için GET metodu
        public ActionResult TalepFormu()
        {
            Random rnd = new Random();
            string[] karakterler = { "A", "B", "C", "D", "E", "F", "G", "H" };
            int k1, k2, k3;
            k1 = rnd.Next(0, karakterler.Length);
            k2 = rnd.Next(0, karakterler.Length);
            k3 = rnd.Next(0, karakterler.Length);
            int s1, s2, s3;
            s1 = rnd.Next(100, 100);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string kod = s1.ToString() + karakterler[k1] + s2 + karakterler[k2] + s3 + karakterler[k3];
            ViewBag.takipkod = kod;
            return View();
        }

        // Personel talep formu için POST metodu
        [HttpPost]
        public ActionResult TalepFormu(PersonelTalep model)
        {
            if (ModelState.IsValid)
            {
                model.Status = null; // Yeni talepler varsayılan olarak "onay bekliyor" durumunda olmalıdır.
                db.PersonelTaleps.Add(model);
                db.SaveChanges();

                // Talep kaydedildikten sonra ilgili kullanıcılara bildirim gönderilmesi gerekebilir.
                // Bildirim gönderme işlemleri burada gerçekleştirilebilir.

                return RedirectToAction("TalepFormu"); // Ana sayfaya yönlendir.
            }
            return View(model);
        }

        // Talebi onaylamak için metot
        public ActionResult Onayla(int id)
        {
            var talep = db.PersonelTaleps.Find(id);
            if (talep != null)
            {
                talep.Status = true; // Talebi onayla.
                db.SaveChanges();

                // Talep onaylandığında ilgili kullanıcıya geri bildirim gönderilmesi gerekebilir.

                return RedirectToAction("OnaytalepDetay"); // Onay bekleyen talepler sayfasına yönlendir.
            }
            return HttpNotFound();
        }

        // Talebi reddetmek için metot
        public ActionResult Reddet(int id)
        {
            var talep = db.PersonelTaleps.Find(id);
            if (talep != null)
            {
                talep.Status = false; // Talebi reddet.
                db.SaveChanges();

                // Talep reddedildiğinde ilgili kullanıcıya geri bildirim gönderilmesi gerekebilir.

                return RedirectToAction("OnaytalepDetay"); // Onay bekleyen talepler sayfasına yönlendir.
            }
            return HttpNotFound();
        }

        // Onay bekleyen talepleri listelemek için metot
        public ActionResult OnayBekleyenTalepler()
        {
            var talepler = db.PersonelTaleps.Where(t => t.Status == null).ToList();
            return View(talepler);
        }

        public ActionResult OnaytalepDetay()
        {
            var detay = db.PersonelTaleps.Where(t => t.Status == null).ToList();
            return View(detay);
        }

    }
}
