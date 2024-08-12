using Microsoft.AspNetCore.Http;
using sahibinden_project.Services;
using System.IO;
using System.Threading.Tasks;

public class FileUploadService : IFileUpload
{
    private readonly string _uploadDirectory;
    private static int _fileCounter = 1; // Statik sayaç, tüm uygulama için geçerli

    // Bu özellik, en son yüklenen dosyanın adını saklar
    public string UploadFileName { get; private set; }

    public FileUploadService()
    {
        _uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
        if (!Directory.Exists(_uploadDirectory))
        {
            Directory.CreateDirectory(_uploadDirectory);
        }
    }

    public async Task<string> UploadFileAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return null;
        }

        // Dosya uzantısını al
        var fileExtension = Path.GetExtension(file.FileName);

        // Benzersiz dosya adını oluştur
        UploadFileName = GenerateUniqueFileName(fileExtension);

        // Dosya yolunu oluştur
        var filePath = Path.Combine(_uploadDirectory, UploadFileName);

        // Dosyayı kaydet
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        // Fotoğrafın web üzerinden erişilebilir URL'sini döndür
        return $"/uploads/{UploadFileName}";
    }

    private string GenerateUniqueFileName(string fileExtension)
    {
        // Benzersiz dosya adını oluştur
        var fileName = $"filename{_fileCounter}{fileExtension}";

        // Sayaç değerini artır
        _fileCounter++;

        return fileName;
    }
}
