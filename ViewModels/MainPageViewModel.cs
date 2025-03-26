using System.Collections.ObjectModel;

namespace SmoothieTub.ViewModels
{
    public class MainPageViewModel
    {
        public ObservableCollection<CategoryModel> Categories { get; set; }

        public MainPageViewModel()
        {
            Categories = new ObservableCollection<CategoryModel>
            {
                new CategoryModel { Name = "Health-Focused Smoothies", ImageUrl = "health_smoothies.png" },
                new CategoryModel { Name = "Nutrient-Based Smoothies", ImageUrl = "nutrient_smoothies.png" },
                //new CategoryModel { Name = "Fruit-Based Smoothies", ImageUrl = "fruit_smoothies.png" },
                //new CategoryModel { Name = "Veggie-Based Smoothies", ImageUrl = "veggie_smoothies.png" },
                //new CategoryModel { Name = "Special Diet Smoothies", ImageUrl = "diet_smoothies.png" },
                //new CategoryModel { Name = "Meal Replacement Smoothies", ImageUrl = "meal_energy_smoothies.png" },
                //new CategoryModel { Name = "Dessert & Indulgent Smoothies", ImageUrl = "dessert_smoothies.png" },
                //new CategoryModel { Name = "Seasonal Smoothies", ImageUrl = "seasonal.png" }
            };
        }
    }

    public class CategoryModel
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
