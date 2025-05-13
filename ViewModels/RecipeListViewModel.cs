using SmoothieTub.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using static AndroidX.Work.ListenableWorker.Result;

namespace SmoothieTub.ViewModels
{
    public class RecipeListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string SubcategoryName { get; set; }
        public ObservableCollection<RecipeModel> Recipes { get; set; }
        public List<RecipeModel> AllRecipes { get; set; } // ✅ Backup list for searching

        public RecipeListViewModel(string subcategoryName)
        {
            SubcategoryName = subcategoryName;
            Recipes = new ObservableCollection<RecipeModel>();
            AllRecipes = new List<RecipeModel>(); // ✅ Initialize backup list

            LoadRecipes(subcategoryName);
        }

        private void LoadRecipes(string subcategoryName)
        {

            string paths = "https://raw.githubusercontent.com/amnk2015/imagestorage/main/";
            string imgpaths = "https://raw.githubusercontent.com/amnk2015/imgstore/main/";
            // Sample recipes (Replace with Firebase data)
            if (subcategoryName == "Detox Smoothies")
            {
                AddRecipe("Detox Smoothies Special", paths+"detox.png"); 
            }
            else if (subcategoryName == "Weight Loss Smoothies")
            {
                AddRecipe("Weight Loss Smoothies Special", paths + "weightloss_special.png"); 
            }
            else if (subcategoryName == "Immunity Boosting Smoothies")
            {
                AddRecipe("Citrus Power Punch", paths + "citrus_power_punch.jpg");
                AddRecipe("Berry Antioxidant Blast", paths + "berry_antioxidant_blast.jpg");
            }
            else if (subcategoryName == "Anti-Inflammatory Smoothies")
            {
                AddRecipe("Anti-Inflammatory Smoothies Special", paths + "anti_inflammatory.png");
            }
            else if (subcategoryName == "High-Protein Smoothies")
            {
                AddRecipe("High-Protein Smoothies Special", paths + "smoothie63.jpg");
                AddRecipe("High-Fiber Smoothies Special", paths + "smoothie63.jpg");
            }
            else if (subcategoryName == "Mixed Fruit Smoothies")
            {
                AddRecipe("Mixed Fruit Smoothies Special", imgpaths + "smoothie16.png"); 
            }
            else if (subcategoryName == "Citrus Smoothies")
            {
                AddRecipe("Citrus Smoothies Special", imgpaths + "smoothie34.png");
                AddRecipe("Citrus Zinger", imgpaths + "citrus-zinger.png");
            }
            else if (subcategoryName == "Tropical Smoothies")
            {
                AddRecipe("Tropical Smoothies Special", imgpaths + "smoothie85.png");
                AddRecipe("Tropical Sunrise", imgpaths + "tropical-sunrise.png");
            }
            else if (subcategoryName == "Berry Smoothies")
            {
                AddRecipe("Berry Smoothies Special", imgpaths + "smoothie62.png");
                AddRecipe("Berry Blast", paths + "berry_blast.png"); 
            }


        }

        private void AddRecipe(string name, string imageFile)
        {
            var recipe = new RecipeModel { Name = name, ImageFile = imageFile };
            Recipes.Add(recipe);  // ✅ Add to UI list
            AllRecipes.Add(recipe); // ✅ Add to backup list
        }

        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public class RecipeModel
    {
        public string Name { get; set; }
        public string ImageFile { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> Instructions { get; set; }
    }
}
