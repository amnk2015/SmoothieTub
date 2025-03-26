using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using SmoothieTub.Models;

namespace SmoothieTub.ViewModels
{
    public class RecipeDetailViewModel : INotifyPropertyChanged
    {
        private readonly FirebaseClient _firebase =
            new FirebaseClient("https://smoothietub-c0432-default-rtdb.firebaseio.com/");

        private string _name;
        private string _description;
        private string _imageFile;
        private string _category;
        private string _subcategory;
        private ObservableCollection<string> _ingredients;
        private ObservableCollection<string> _instructions;
        private ObservableCollection<string> _health;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string ImageFile
        {
            get => _imageFile;
            set
            {
                _imageFile = value;
                OnPropertyChanged(nameof(ImageFile));
            }
        }

        public string Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        public string Subcategory
        {
            get => _subcategory;
            set
            {
                _subcategory = value;
                OnPropertyChanged(nameof(Subcategory));
            }
        }

        public ObservableCollection<string> Ingredients
        {
            get => _ingredients;
            set
            {
                _ingredients = value;
                OnPropertyChanged(nameof(Ingredients));
            }
        }

        public ObservableCollection<string> Instructions
        {
            get => _instructions;
            set
            {
                _instructions = value;
                OnPropertyChanged(nameof(Instructions));
            }
        }

        
      public ObservableCollection<string> HealthBenefits
        {
            get => _health;
            set
            {
                _health = value;
                OnPropertyChanged(nameof(HealthBenefits));
            }
        }

        private Dictionary<string, string> categoryToSubcategoryMap = new Dictionary<string, string>();

        public RecipeDetailViewModel(string recipeName)
        {
            Ingredients = new ObservableCollection<string>();
            Instructions = new ObservableCollection<string>();
            HealthBenefits = new ObservableCollection<string>();
            LoadRecipeData(recipeName);
        }

        private async void LoadRecipeData(string recipeName)
        {
            try
            {
                //// Load Categories with Subcategories
                //var categoriesData = await _firebase
                //    .Child("Categories")
                //    .OnceAsync<dynamic>(); // Use dynamic to handle array response

                //foreach (var categoryItem in categoriesData)
                //{
                //    var categoryDict = categoryItem.Object as IDictionary<string, object>;

                //    if (categoryDict != null)
                //    {
                //        // Extract category properties
                //        string categoryName = categoryDict.ContainsKey("name") ? categoryDict["name"].ToString() : "Unknown Category";
                //        var subcategories = categoryDict.ContainsKey("subcategories") ? categoryDict["subcategories"] as List<object> : null;

                //        if (subcategories != null)
                //        {
                //            foreach (var subcategoryObj in subcategories)
                //            {
                //                var subcategoryDict = subcategoryObj as IDictionary<string, object>;
                //                if (subcategoryDict != null && subcategoryDict.ContainsKey("name"))
                //                {
                //                    string subcategoryName = subcategoryDict["name"].ToString();
                //                    categoryToSubcategoryMap[subcategoryName] = categoryName;
                //                }
                //            }
                //        }
                //    }
                //}



                // Load Smoothie Data
                var smoothiesData = await _firebase
                    .Child("Smoothies")
                    .OnceAsync<Smoothie>();

                var recipe = smoothiesData
                    .Select(s => s.Object)
                    .FirstOrDefault(s => s.Name == recipeName);

                if (recipe != null)
                {
                    Name = recipe.Name;
                    Description = recipe.Description;
                    ImageFile = recipe.ImageUrl;
                    Category = recipe.Category;

                    // Assign Subcategory Dynamically
                    Subcategory = categoryToSubcategoryMap.ContainsKey(recipe.Category)
                        ? categoryToSubcategoryMap[recipe.Category]
                        : "Unknown";

                    Ingredients.Clear();
                    foreach (var ingredient in recipe.Ingredients)
                    {
                        Ingredients.Add(ingredient);
                    }

                    Instructions.Clear();
                    foreach (var instruction in recipe.Instructions)
                    {
                        Instructions.Add(instruction);
                    }

                    HealthBenefits.Clear();
                    foreach (var healthBenefits in recipe.HealthBenefits)
                    {
                        HealthBenefits.Add(healthBenefits);
                    }

                }
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error fetching recipe: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
