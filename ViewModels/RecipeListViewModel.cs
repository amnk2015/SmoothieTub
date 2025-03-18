using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

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
            // Sample recipes (Replace with Firebase data)
            if (subcategoryName == "Detox Smoothies")
            {
                AddRecipe("Green Detox", "detox.png");
                AddRecipe("Cucumber Cleanse", "fruit_smoothies.png");
                AddRecipe("Lemon Ginger Flush", "low.png");
            }
            else if (subcategoryName == "Weight Loss Smoothies")
            {
                AddRecipe("Fat Burner", "fat_burner.png");
                AddRecipe("Berry Slim", "berry_slim.png");
                AddRecipe("Metabolism Booster", "metabolism_boost.png");
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
    }
}
