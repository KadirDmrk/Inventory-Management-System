using System.Linq;
using System.Web.Mvc;
using Inventory_Management_System.Models.Class;
using PagedList;
using PagedList.Mvc;



namespace Inventory_Management_System.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        Context c = new Context();

        // GET: /Category/Index
        public ActionResult Index(string p, int page = 1)
        {
            var categories = c.Categories.ToList();
            

            if (!string.IsNullOrEmpty(p))
            {
             
                string searchKeyword = p.ToLower();
                categories = categories.Where(cat => cat.CategoryName.ToLower().Contains(searchKeyword)).ToList();
            }


            var pagedCategories = categories.ToPagedList(page, 5);

          
            return View(pagedCategories);
        }


        [HttpGet] // İşlem gerçekleşmezse sayfayı yükle 
        public ActionResult CategoryAdd()
        {
            
            return View();
        }
        [HttpPost] // Sayfada butona bastığım zaman kaydetme işlemi gerçekleştir. 
        public ActionResult CategoryAdd(Category p1)
        {
            TempData["AlertMessage"] = "Kategori  Başarı ile Eklendi.";

            if (!ModelState.IsValid)
            {
                return View("CategoryAdd");
            }
            c.Categories.Add(p1);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult CategoryDelete(int id)
        {
            var ctg = c.Categories.Find(id);
            c.Categories.Remove(ctg);
            c.SaveChanges();
            TempData["AlertMessage"] = "Kategori  Başarı ile Silindi.";
            return RedirectToAction("Index");
        }

        public ActionResult CategoryImport(int id)
        {
            var ctg = c.Categories.Find(id);
            return View("CategoryImport", ctg);
        }

        public ActionResult CategoryUpdate(Category k)
        {
            var ktgr = c.Categories.Find(k.CategoryID);
            ktgr.CategoryName = k.CategoryName;
            c.SaveChanges();
            TempData["AlertMessage"] = "Kategori Başarı ile Güncellendi.";
            return RedirectToAction("Index");
        }

        public ActionResult CategoryDetail(int id)
        {

            var values = c.Products.Where(x => x.Categoryid == id).ToList();
            var dpt = c.Categories.Where(x => x.CategoryID == id).Select(y => y.CategoryName).FirstOrDefault();//linq sorgusu dashboarda görmek için burda yaptık  
            ViewBag.d = dpt;
            return View(values);
        }
    }
}