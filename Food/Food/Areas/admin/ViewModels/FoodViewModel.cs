
using Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Areas.admin.ViewModels
{
    public class FoodViewModel
    {
        public int FoodID { get; set; }
        public string FoodName { get; set; }
        public string Address { get; set; }
        public string CityName { get; set; }
        public string FoodCateName { get; set; }
        diadiemanuongEntities db;
        public FoodViewModel()
        {
            db = new diadiemanuongEntities();
        }
        public IEnumerable<FoodViewModel> getFoodViewModel()
        {
            IEnumerable<FoodViewModel> fdViewModel = (from o in db.Foods
                                        join i in db.FoodCategories on o.FoodCategoryID equals i.FoodCategoryID
                                        join c in db.Cities on o.CityID equals c.CityID
                                        select new FoodViewModel {
                                            FoodID = o.FoodID,
                                            FoodName = o.FoodName,
                                            Address = o.Address,
                                            CityName = c.CityName,
                                            FoodCateName = i.FoodCategoryName
                                        });
            return fdViewModel;
        }
        public FoodViewModel ConvertFoodViewModel(Food.Food food)
        {
            FoodViewModel fvdm = new FoodViewModel();
            fvdm.FoodID = food.FoodID;
            fvdm.FoodName = food.FoodName;
            fvdm.Address = food.Address;
            fvdm.CityName = food.City.CityName;
            return fvdm;
        }
    }
}