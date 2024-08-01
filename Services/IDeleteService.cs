namespace sahibinden_project.Services
{
    public interface IDeleteService
    {
        public Task DeleteListingById(int id);
        Task Clean();
        Task DeleteUserById(int id);
        Task DeleteUserByUsername(string username);
    }
}
