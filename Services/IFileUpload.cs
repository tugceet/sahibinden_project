namespace sahibinden_project.Services
{
    public interface IFileUpload
    {
        Task<string> UploadFileAsync(IFormFile file );
    }

}
