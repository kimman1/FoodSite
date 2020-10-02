using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Food.Areas.admin.Controllers
{
    public class FoodCatController : Controller
    {
        diadiemanuongEntities db = new diadiemanuongEntities();
        // GET: admin/FoodCat
        public async Task<ActionResult> Index()
        {
            var p = db.FoodCategories;
            return View(await p.ToListAsync());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FoodCategory FoodCat)
        {
            if (ModelState.IsValid)
            {
                db.FoodCategories.Add(FoodCat);
                db.SaveChanges();
            }
            return RedirectToAction("Index"); 
        }
        public ActionResult Delete(int id)
        {
            var p = db.FoodCategories.Find(id);
            return View(p);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection fc)
        {
            var p = db.FoodCategories.Find(id);
            db.FoodCategories.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index"); 
        }
        public ActionResult Edit(int id)
        {
            var p = db.FoodCategories.Where(s => s.FoodCategoryID == id).FirstOrDefault();
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(FoodCategory FoodCat)
        {

            db.Entry(FoodCat).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Details(int id)
        {

            return View();
        }
    }
}