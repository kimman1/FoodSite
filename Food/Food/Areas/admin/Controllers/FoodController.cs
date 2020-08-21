using Areas.admin.ViewModels;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security;
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
        public ActionResult Create()
        {
            //List City
            List<City> listCities = db.Cities.ToList();
            SelectList citiesSeleteList = new SelectList(listCities, "CityID", "CityName");
            ViewBag.SelectListCity = citiesSeleteList;
            // List Food Cate
            List<FoodCategory> listFoodCate = db.FoodCategories.ToList();
            SelectList foodCateSelectList = new SelectList(listFoodCate, "FoodCategoryID", "FoodCategoryName");
            ViewBag.SelectListFoodCateName = foodCateSelectList;
            return View();
        }
        [HttpPost]
        public ActionResult Create(FoodViewModel fvmd, FormCollection fc)
        {
            if (ModelState.IsValid)
            {
                FoodViewModel foodDao = new FoodViewModel();
                fvmd.CityName = fc["CityID"].ToString();
                fvmd.FoodCateName = fc["FoodCategoryID"].ToString();
                db.Foods.Add(foodDao.ConvertToFood(fvmd));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fvmd);
        }
        public ActionResult Edit(int id)
        {
            var p = db.Foods.Where(s => s.FoodID == id).FirstOrDefault();
            // Food Cate dropdown list
            List<FoodCategory> FoodCate = db.FoodCategories.ToList();
            SelectList FoodCateList = new SelectList(FoodCate, "FoodCategoryID", "FoodCategoryName",p.FoodCategoryID);
            ViewBag.FoodCategoryList = FoodCateList;
            // City dropdown list
            List<City> Cities = db.Cities.ToList();
            SelectList citiesList = new SelectList(Cities, "CityID", "CityName",p.CityID.ToString());
            ViewBag.CitiesList = citiesList;
            //Convert Food to FoodViewModel
            FoodViewModel fvdm = new FoodViewModel();
            return View(fvdm.ConvertToFoodViewModel(p));
        }
        [HttpPost]
        public ActionResult Edit(FoodViewModel fvmd, FormCollection fc)
        {
            if (ModelState.IsValid)
            {
                fvmd.CityName = fc["CityID"].ToString();
                fvmd.FoodCateName = fc["FoodCatName"].ToString();
                FoodViewModel foodDao = new FoodViewModel();
                Food food = foodDao.ConvertToFood(fvmd);
                db.Entry(food).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fvmd);
        }
        public ActionResult Delete(int? id)
        {
            FoodViewModel foodDao = new FoodViewModel();
            return View(foodDao.ConvertToFoodViewModel(db.Foods.Where(s => s.FoodID == id).FirstOrDefault()));
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var p = db.Foods.Find(id);
            db.Foods.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}