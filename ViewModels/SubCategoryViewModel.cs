using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SmoothieTub.ViewModels
{
    public class SubCategoryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _categoryName;
        public string CategoryName
        {
            get => _categoryName;
            set
            {
                _categoryName = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<SubCategoryModel> Subcategories { get; set; }

        public SubCategoryViewModel(string categoryName)
        {
            CategoryName = categoryName;
            Subcategories = new ObservableCollection<SubCategoryModel>();

            // Sample data - You can replace this with Firebase data
            if (categoryName == "Health-Focused Smoothies")
            {
                Subcategories.Add(new SubCategoryModel { Name = "Detox Smoothies", ImageFile = "detox.png" });
                Subcategories.Add(new SubCategoryModel { Name = "Weight Loss Smoothies", ImageFile = "weight.png" });
                Subcategories.Add(new SubCategoryModel { Name = "Immunity Boosting Smoothies", ImageFile = "immunity.png" });
                Subcategories.Add(new SubCategoryModel { Name = "Anti-Inflammatory Smoothies", ImageFile = "anti_inflammatory.png" });
            }
            else if (categoryName == "Nutrient-Based Smoothies")
            {
                Subcategories.Add(new SubCategoryModel { Name = "High-Protein Smoothies", ImageFile = "protein.png" });
                Subcategories.Add(new SubCategoryModel { Name = "Low-Calorie Smoothies", ImageFile = "low_calorie.png" });
                Subcategories.Add(new SubCategoryModel { Name = "High-Fiber Smoothies", ImageFile = "high_fiber.png" });
                Subcategories.Add(new SubCategoryModel { Name = "Low-Sugar Smoothies", ImageFile = "low_sugar.png" });
            }
            else if (categoryName == "Fruit-Based Smoothies")
            {
                Subcategories.Add(new SubCategoryModel { Name = "Berry Smoothies", ImageFile = "berry.png" });
                Subcategories.Add(new SubCategoryModel { Name = "Tropical Smoothies", ImageFile = "tropical.png" });
                Subcategories.Add(new SubCategoryModel { Name = "Citrus Smoothies", ImageFile = "citrus.png" });
                Subcategories.Add(new SubCategoryModel { Name = "Mixed Fruit Smoothies", ImageFile = "mixed_fruit.png" });
            }
            else if (categoryName == "Veggie-Based Smoothies")
            {
                Subcategories.Add(new SubCategoryModel { Name = "Green Smoothies", ImageFile = "green.png" });
                Subcategories.Add(new SubCategoryModel { Name = "Root-Based Smoothies", ImageFile = "root_based.png" });
            }
            else if (categoryName == "Special Diet Smoothies")
            {
                Subcategories.Add(new SubCategoryModel { Name = "Vegan Smoothies", ImageFile = "vegan.png" });
                Subcategories.Add(new SubCategoryModel { Name = "Keto-Friendly Smoothies", ImageFile = "keto.png" });
                Subcategories.Add(new SubCategoryModel { Name = "Paleo Smoothies", ImageFile = "paleo.png" });
                Subcategories.Add(new SubCategoryModel { Name = "Gluten-Free Smoothies", ImageFile = "gluten_free.png" });
            }
            else if (categoryName == "Meal Replacement & Energy Smoothies")
            {
                Subcategories.Add(new SubCategoryModel { Name = "Breakfast Smoothies", ImageFile = "breakfast.png" });
                Subcategories.Add(new SubCategoryModel { Name = "Post-Workout Smoothies", ImageFile = "post_workout.png" });
                Subcategories.Add(new SubCategoryModel { Name = "Energy-Boosting Smoothies", ImageFile = "energy_boosting.png" });
                Subcategories.Add(new SubCategoryModel { Name = "Filling & Satisfying Smoothies", ImageFile = "filling.png" });
            }
            else if (categoryName == "Dessert & Indulgent Smoothies")
            {
                Subcategories.Add(new SubCategoryModel { Name = "Chocolate-Based Smoothies", ImageFile = "chocolate.png" });
                Subcategories.Add(new SubCategoryModel { Name = "Peanut Butter Smoothies", ImageFile = "peanut_butter.png" });
                Subcategories.Add(new SubCategoryModel { Name = "Ice Cream or Milkshake-Style Smoothies", ImageFile = "milkshake.png" });
            }
            else if (categoryName == "Seasonal Smoothies")
            {
                Subcategories.Add(new SubCategoryModel { Name = "Summer Refreshing Smoothies", ImageFile = "summer.png" });
                Subcategories.Add(new SubCategoryModel { Name = "Winter Warming Smoothies", ImageFile = "winter.png" });
            }

        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

      

    }

    public class SubCategoryModel
    {
        public string Name { get; set; }
        public string ImageFile { get; set; }
    }
}
