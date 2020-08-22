
using Food;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Areas.admin.ViewModels
{
    public class FoodViewModel
    {
        [DisplayName("Food ID")]
        public int FoodID { get; set; }
        [DisplayName("Tên Món Ăn")]
        public string FoodName { get; set; }
        [DisplayName("Địa Chỉ")]
        public string Address { get; set; }
        [DisplayName("Thành Phố")]
        public string CityName { get; set; }
        [DisplayName("Loại Món Ăn")]
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
        public FoodViewModel ConvertToFoodViewModel(Food.Food food)
        {
            FoodViewModel fvdm = new FoodViewModel();
            fvdm.FoodID = food.FoodID;
            fvdm.FoodName = food.FoodName;
            fvdm.Address = food.Address;
            fvdm.CityName = food.City.CityName;
            fvdm.FoodCateName = food.FoodCategory.FoodCategoryName;
            return fvdm;
        }
        public Food.Food ConvertToFood(FoodViewModel fvmd)
        {
            
            Food.Food food = new Food.Food();
            food.FoodID = fvmd.FoodID;
            food.FoodName = fvmd.FoodName;
            food.Address = fvmd.Address;
            food.CityID = Convert.ToInt32(fvmd.CityName);
            food.FoodCategoryID = Convert.ToInt32(fvmd.FoodCateName);
            return food;
        }
    }
}