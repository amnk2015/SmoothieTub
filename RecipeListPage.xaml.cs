using SmoothieTub.Models;
using SmoothieTub.ViewModels;

namespace SmoothieTub 
{
    public partial class RecipeListPage : ContentPage
    {
        public RecipeListPage(string selectedRecipe)
        {
            InitializeComponent();
           BindingContext = new RecipeListViewModel(selectedRecipe);
           // BindingContext = selectedRecipe;
        }

        // Handle Recipe Click Event
        private async void OnRecipeTapped(object sender, EventArgs e)
        {
            if (sender is Frame frame && frame.BindingContext is RecipeModel selectedRecipe)
            {
                await Navigation.PushAsync(new RecipeDetailPage(selectedRecipe));
            }
        }


        // Handle Search Bar Input
        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            var viewModel = BindingContext as RecipeListViewModel;
            if (viewModel != null)
            {
                string searchText = e.NewTextValue.ToLower();

                // Filter recipes dynamically
                var filteredRecipes = viewModel.AllRecipes
                    .Where(recipe => recipe.Name.ToLower().Contains(searchText))
                    .ToList();

                viewModel.Recipes.Clear();
                foreach (var recipe in filteredRecipes)
                {
                    viewModel.Recipes.Add(recipe);
                }
            }
        }
    }
}
