using Firebase.Storage;
using System;
using System.IO;
using System.Threading.Tasks;

public class FirebaseStorageService
{
    private readonly FirebaseStorage _firebaseStorage;

    public FirebaseStorageService()
    {
        _firebaseStorage = new FirebaseStorage("your-storage-bucket.appspot.com");
    }

    public async Task<string> UploadImage(Stream fileStream, string fileName)
    {
        var imageUrl = await _firebaseStorage
            .Child("smoothie_images")
            .Child(fileName)
            .PutAsync(fileStream);

        return imageUrl; // Returns the public URL of the uploaded image
    }
}
