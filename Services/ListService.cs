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

    public async Task Clean()
    {
        _db.Users.RemoveRange(_db.Users);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteUserById(int id)
    {
        var user = await _db.Users.FindAsync(id);
        if (user != null)
        {
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
        }
    }

    public async Task DeleteUserByUsername(string username)
    {
        var user = await _db.Users.SingleOrDefaultAsync(u => u.Username == username);
        if (user != null)
        {
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
        }
    }
}
