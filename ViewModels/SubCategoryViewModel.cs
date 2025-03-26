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
            string paths = "https://raw.githubusercontent.com/amnk2015/imagestorage/main/";
            // Sample data - You can replace this with Firebase data
            if (categoryName == "Health-Focused Smoothies")
            {
                Subcategories.Add(new SubCategoryModel { Name = "Detox Smoothies", ImageFile = paths + "detox.png" });
                Subcategories.Add(new SubCategoryModel { Name = "Weight Loss Smoothies", ImageFile = paths + "weight.png" });
                Subcategories.Add(new SubCategoryModel { Name = "Immunity Boosting Smoothies", ImageFile = paths + "immunity.png" });
                Subcategories.Add(new SubCategoryModel { Name = "Anti-Inflammatory Smoothies", ImageFile = paths + "anti_inflammatory.png" });
            }
            else if (categoryName == "Nutrient-Based Smoothies")
            {
                Subcategories.Add(new SubCategoryModel { Name = "High-Protein Smoothies", ImageFile = paths + "protein.png" });
              //  Subcategories.Add(new SubCategoryModel { Name = "Low-Calorie Smoothies", ImageFile = paths + "low_calorie.png" });
                //Subcategories.Add(new SubCategoryModel { Name = "High-Fiber Smoothies", ImageFile = paths + "high_fiber.png" });
                //Subcategories.Add(new SubCategoryModel { Name = "Low-Sugar Smoothies", ImageFile = paths + "low_sugar.png" });
            }
            //else if (categoryName == "Fruit-Based Smoothies")
            //{
            //    Subcategories.Add(new SubCategoryModel { Name = "Berry Smoothies", ImageFile = paths + "berry.png" });
            //    Subcategories.Add(new SubCategoryModel { Name = "Tropical Smoothies", ImageFile = paths + "tropical.png" });
            //    Subcategories.Add(new SubCategoryModel { Name = "Citrus Smoothies", ImageFile = paths + "citrus.png" });
            //    Subcategories.Add(new SubCategoryModel { Name = "Mixed Fruit Smoothies", ImageFile = paths + "mixed_fruit.png" });
            //}
            //else if (categoryName == "Veggie-Based Smoothies")
            //{
            //    Subcategories.Add(new SubCategoryModel { Name = "Green Smoothies", ImageFile = paths + "green.png" });
            //    Subcategories.Add(new SubCategoryModel { Name = "Root-Based Smoothies", ImageFile = paths + "root_based.png" });
            //}
            //else if (categoryName == "Special Diet Smoothies")
            //{
            //    Subcategories.Add(new SubCategoryModel { Name = "Vegan Smoothies", ImageFile = paths + "vegan.png" });
            //    Subcategories.Add(new SubCategoryModel { Name = "Keto-Friendly Smoothies", ImageFile = paths + "keto.png" });
            //    Subcategories.Add(new SubCategoryModel { Name = "Paleo Smoothies", ImageFile = paths + "paleo.png" });
            //    Subcategories.Add(new SubCategoryModel { Name = "Gluten-Free Smoothies", ImageFile = paths + "gluten_free.png" });
            //}
            //else if (categoryName == "Meal Replacement & Energy Smoothies")
            //{
            //    Subcategories.Add(new SubCategoryModel { Name = "Breakfast Smoothies", ImageFile =  paths + "breakfast.png" });
            //    Subcategories.Add(new SubCategoryModel { Name = "Post-Workout Smoothies", ImageFile = paths + "post_workout.png" });
            //    Subcategories.Add(new SubCategoryModel { Name = "Energy-Boosting Smoothies", ImageFile = paths + "energy_boosting.png" });
            //    Subcategories.Add(new SubCategoryModel { Name = "Filling & Satisfying Smoothies", ImageFile = paths + "filling.png" });
            //}
            //else if (categoryName == "Dessert & Indulgent Smoothies")
            //{
            //    Subcategories.Add(new SubCategoryModel { Name = "Chocolate-Based Smoothies", ImageFile = paths + "chocolate.png" });
            //    Subcategories.Add(new SubCategoryModel { Name = "Peanut Butter Smoothies", ImageFile = paths + "peanut_butter.png" });
            //    Subcategories.Add(new SubCategoryModel { Name = "Ice Cream or Milkshake-Style Smoothies", ImageFile = paths + "milkshake.png" });
            //}
            //else if (categoryName == "Seasonal Smoothies")
            //{
            //    Subcategories.Add(new SubCategoryModel { Name = "Summer Refreshing Smoothies", ImageFile = paths + "summer.png" });
            //    Subcategories.Add(new SubCategoryModel { Name = "Winter Warming Smoothies", ImageFile = paths + "winter.png" });
            //}

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
