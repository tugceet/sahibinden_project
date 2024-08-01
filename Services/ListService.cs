using Microsoft.EntityFrameworkCore;

namespace sahibinden_project;

public class ListService : IListService
{

    private readonly SahibindenDbContext _db;

    public ListService(SahibindenDbContext db)
    {
        _db = db;
    }

    public async Task<List<User>> GetUsers()
    {
        return await _db.Users.ToListAsync();
    }

    public async Task<User> GetUser(int id)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user == null)
        {
            throw new Exception("Null user");
        }
        return user;
    }

    public async Task<User> GetUser(string username)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == username);
        if (user == null)
        {
            throw new Exception("Null user");
        }
        return user;
    }

  
}
