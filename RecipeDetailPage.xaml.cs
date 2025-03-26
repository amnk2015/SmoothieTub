using SmoothieTub.ViewModels;

namespace SmoothieTub;

public partial class RecipeDetailPage : ContentPage
{
    public RecipeDetailPage(string selectedRecipe)
    {
        InitializeComponent(); 
        BindingContext = new RecipeDetailViewModel(selectedRecipe);
    }



}