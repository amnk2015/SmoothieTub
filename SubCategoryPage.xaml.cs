using SmoothieTub.ViewModels;

namespace SmoothieTub
{
    public partial class SubCategoryPage : ContentPage
    {
        public SubCategoryPage(string categoryName)
        {
            InitializeComponent();
            BindingContext = new SubCategoryViewModel(categoryName);
        }

        // Handle Subcategory Tap Event
        private async void OnSubCategoryTapped(object sender, EventArgs e)
        {
            if (sender is Frame frame && frame.BindingContext is SubCategoryModel selectedSubCategory)
            {
                await Navigation.PushAsync(new RecipeListPage(selectedSubCategory.Name));
            }
        }
    }
}
