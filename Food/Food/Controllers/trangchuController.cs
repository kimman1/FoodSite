using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Food.Controllers
{
    public class trangchuController : Controller
    {
        diadiemanuongEntities db = new diadiemanuongEntities();
        // GET: trangchu
        public async Task<ActionResult> Index()
        {
            return View(await db.Cities.ToListAsync());
        }
        public async Task<ActionResult> Details(int id)
        {
            ViewBag.CityID = id;
            return View(await db.FoodCategories.ToListAsync());
        }
        public ActionResult FoodCategoryDetails(int id, int CityID)
        {
            var p = db.Foods.Where(s => s.CityID == CityID & s.FoodCategoryID == id);
            ViewData["FoodCatId"] = id;
            ViewData["CityID"] = CityID;
            return View(p);
        }
        public ActionResult ImageList(int id)
        {
            var p = db.Images.Where(s => s.FoodID == id);
            Food food = db.Foods.Where(s => s.FoodID == id).FirstOrDefault();
            ViewData["FoodName"] = food.FoodName;
            ViewData["FoodAddress"] = food.Address;
            ViewData["FoodCity"] = db.Cities.Where(s => s.CityID == food.CityID).Select(s=>s.CityName).FirstOrDefault();
            return View(p);
        }
    }
}