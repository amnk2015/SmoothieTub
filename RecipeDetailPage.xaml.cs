using SmoothieTub.ViewModels;

namespace SmoothieTub;

public partial class RecipeDetailPage : ContentPage
{
    public RecipeDetailPage(RecipeModel selectedRecipe)
    {
        InitializeComponent();
        BindingContext = selectedRecipe;
    }

    private async void OnRecipeTapped(object sender, EventArgs e)
    {
        if (sender is Frame frame && frame.BindingContext is RecipeModel selectedRecipe)
        {
            await Navigation.PushAsync(new RecipeDetailPage(selectedRecipe)); // ✅ Passing RecipeModel, not string
        }
    }
}