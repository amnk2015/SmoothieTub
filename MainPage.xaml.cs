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
            Categories.Add(new Category { Name = "Health-Focused Smoothies", ImageUrl = "health_smoothies.png" });
            Categories.Add(new Category { Name = "Nutrient-Based Smoothies", ImageUrl = "nutrient_smoothies.png" });
            Categories.Add(new Category { Name = "Fruit-Based Smoothies", ImageUrl = "fruit_smoothies.png" });
            Categories.Add(new Category { Name = "Veggie-Based Smoothies", ImageUrl = "veggie_smoothies.png" });
            Categories.Add(new Category { Name = "Special Diet Smoothies", ImageUrl = "diet_smoothies.png" });
            Categories.Add(new Category { Name = "Meal Replacement Smoothies", ImageUrl = "meal_energy_smoothies.png" });
            Categories.Add(new Category { Name = "Dessert & Indulgent Smoothies", ImageUrl = "dessert_smoothies.png" });
            Categories.Add(new Category { Name = "Veggie-Based Smoothies", ImageUrl = "veggie_smoothies.png" });
            Categories.Add(new Category { Name = "Seasonal Smoothies", ImageUrl = "seasonal.png" }); 

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
