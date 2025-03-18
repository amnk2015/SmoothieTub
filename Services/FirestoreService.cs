using Firebase.Database;
using Firebase.Database.Query;
using SmoothieTub.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class FirebaseService
{
    private readonly FirebaseClient _firebaseClient;

    public FirebaseService()
    {
        _firebaseClient = new FirebaseClient("https://smoothietub-c0432-default-rtdb.firebaseio.com/");
    }

    public async Task AddSmoothie(Smoothie smoothie)
    {
        await _firebaseClient
            .Child("Smoothies")
            .PostAsync(smoothie);
    }

    public async Task<List<Smoothie>> GetSmoothies()
    {
        return (await _firebaseClient
            .Child("Smoothies")
            .OnceAsync<Smoothie>())
            .Select(item => item.Object)
            .ToList();
    }
}
