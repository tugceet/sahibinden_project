namespace sahibinden_project;

public interface IListService
{
    Task<List<User>> GetUsers();
    Task<User> GetUser(int id);
    Task<User> GetUser(string username);
    Task Clean();
    Task DeleteUserById(int id);
    Task DeleteUserByUsername(string username);

}
