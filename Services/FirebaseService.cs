using Firebase.Database;
using SmoothieTub.Models;

namespace SmoothieTub.Services
{
    public class FirebaseService
    {
        private readonly FirebaseClient _firebaseClient;

        public FirebaseService()
        {
            _firebaseClient = new FirebaseClient("https://smoothietub-c0432-default-rtdb.firebaseio.com/");
        }

        public async Task<List<Smoothie>> GetSmoothies()
        {
            var smoothiesData = await _firebaseClient
                .Child("Smoothies")
                .OnceAsync<Smoothie>();

            return smoothiesData
                .Select(item => item.Object) // Convert to Smoothie objects
                .ToList();
        }
    }
}
