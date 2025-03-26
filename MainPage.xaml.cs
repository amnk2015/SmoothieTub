using Android.Webkit;
using SmoothieTub.Models;
using SmoothieTub.ViewModels;
using System.Collections.ObjectModel;

namespace SmoothieTub
{
    public partial class MainPage : ContentPage
    {
        private readonly FirebaseService _firebaseService;
        public ObservableCollection<Smoothie> Smoothies { get; set; }
        public ObservableCollection<Category> Categories { get; set; }

        public MainPage()
        {
            InitializeComponent();

            _firebaseService = new FirebaseService();
            Smoothies = new ObservableCollection<Smoothie>();
            Categories = new ObservableCollection<Category>();

            BindingContext = this; // Keep this, remove the extra ViewModel setting.

            LoadCategories();
            LoadSmoothies();
        }
    
        private async void LoadSmoothies()
        {
            var smoothies = await _firebaseService.GetSmoothies();
            foreach (var smoothie in smoothies)
            {
                Smoothies.Add(smoothie);
            }
        }


        private void LoadCategories()
        {
            string paths = "https://raw.githubusercontent.com/amnk2015/imagestorage/main/";
            Categories.Add(new Category { Name = "Health-Focused Smoothies", ImageUrl = paths + "health_smoothies.png" });
            Categories.Add(new Category { Name = "Nutrient-Based Smoothies", ImageUrl = paths + "nutrient_smoothies.png" });
            //Categories.Add(new Category { Name = "Fruit-Based Smoothies", ImageUrl = paths + "fruit_smoothies.png" });
            //Categories.Add(new Category { Name = "Veggie-Based Smoothies", ImageUrl = paths + "veggie_smoothies.png" });
            //Categories.Add(new Category { Name = "Special Diet Smoothies", ImageUrl = paths + "diet_smoothies.png" });
            //Categories.Add(new Category { Name = "Meal Replacement Smoothies", ImageUrl = paths + "meal_energy_smoothies.png" });
            //Categories.Add(new Category { Name = "Dessert & Indulgent Smoothies", ImageUrl = paths + "dessert_smoothies.png" });
            //Categories.Add(new Category { Name = "Veggie-Based Smoothies", ImageUrl = paths + "veggie_smoothies.png" });
            //Categories.Add(new Category { Name = "Seasonal Smoothies", ImageUrl = paths + "seasonal.png" }); 

        }


        private async void OnCategoryTapped(object sender, TappedEventArgs e)
        {
            if (e.Parameter is Category selectedCategory)
            {
                await Navigation.PushAsync(new SubCategoryPage(selectedCategory.Name));
            }
        }

    }
}
