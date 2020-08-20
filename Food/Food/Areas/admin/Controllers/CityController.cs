using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Food.Areas.admin.Controllers
{
    public class CityController : Controller
    {
        diadiemanuongEntities db = new diadiemanuongEntities();
        // GET: admin/City
        public ActionResult Index()
        {
            return View(db.Cities);
        }
        public ActionResult Create()
        {

             return View();
        }
        [HttpPost]
        public ActionResult Create(City cities)
        {
            db.Cities.Add(cities);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            return View(db.Cities.Where(s => s.CityID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(City cites)
        {
            db.Entry(cites).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(db.Cities.Where(s => s.CityID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(City cities)
        {
            db.Cities.Remove(cities);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}