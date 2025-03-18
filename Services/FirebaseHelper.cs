using Firebase.Database;
using SmoothieTub.Models;

public class FirebaseHelper
{
    private static readonly FirebaseClient firebase = new FirebaseClient("https://smoothietub-c0432-default-rtdb.firebaseio.com/");

    public static async Task<List<Recipe>> GetRecipes()
    {
        return (await firebase
            .Child("Recipes")
            .OnceAsync<Recipe>())
            .Select(item => new Recipe
            {
                Name = item.Object.Name,
                ImageFile = item.Object.ImageFile,
                Description = item.Object.Description,
                Ingredients = item.Object.Ingredients,
                Instructions = item.Object.Instructions
            }).ToList();
    }
}
