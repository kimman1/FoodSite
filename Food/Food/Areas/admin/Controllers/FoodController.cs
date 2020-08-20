using Areas.admin.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Food.Areas.admin.Controllers
{
    public class FoodController : Controller
    {
        diadiemanuongEntities db = new diadiemanuongEntities();
        public ActionResult Index()
        {
            FoodViewModel fd = new FoodViewModel();
            return View(fd.getFoodViewModel());
        }
        public ActionResult Edit(int id)
        {
            var p = db.Foods.Where(s => s.FoodID == id).FirstOrDefault();
            int cityid = (int)p.CityID;
            int foodcatid = (int)p.FoodCategoryID;
            // Food Cate dropdown list
            List<FoodCategory> FoodCate = db.FoodCategories.ToList();
            SelectList FoodCateList = new SelectList(FoodCate, "FoodCategoryID", "FoodCategoryName",foodcatid);
            ViewBag.FoodCategoryList = FoodCateList;
            // City dropdown list
            List<City> Cities = db.Cities.ToList();
            SelectList citiesList = new SelectList(Cities, "CityID", "CityName",3);
            ViewBag.CitiesList = citiesList;
            //Convert Food to FoodViewModel
            FoodViewModel fvdm = new FoodViewModel();
            return View(fvdm.ConvertFoodViewModel(p));
        }
        [HttpPost]
        public ActionResult Edit(FoodViewModel fvmd)
        {
            return View();
        }
    }
}