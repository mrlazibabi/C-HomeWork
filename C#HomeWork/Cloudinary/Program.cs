using CloudinaryDotNet; 
using CloudinaryDotNet.Actions;

var cloudinary = new Cloudinary(new Account(
    "dtyghu5cm", // Cloud name
    "227473482297885", // API key
    "uTa_zV01JpuLFImYGw7Lj2LzF1E" // API secret
));

string imagePath = @"C:\Users\Tuan Anh\Pictures\anonymous.png"; // Đường dẫn đến file ảnh cần tải lên

// Tải ảnh lên
ImageUploadParams uploadParams = new ImageUploadParams()
{
    File = new FileDescription(imagePath)
};
ImageUploadResult uploadResult = await cloudinary.UploadAsync(uploadParams);

// In ra URL của ảnh
Console.WriteLine("Image uploaded: " + uploadResult.SecureUrl);