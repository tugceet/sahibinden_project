using Microsoft.AspNetCore.Http;
using sahibinden_project.Services;
using System.IO;
using System.Threading.Tasks;

public class FileUploadService : IFileUpload
{
    private readonly string _uploadDirectory;

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

        var filePath = Path.Combine(_uploadDirectory, file.FileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        // Fotoğrafın web üzerinden erişilebilir URL'sini döndür
        return $"/uploads/{file.FileName}";
    }
}
