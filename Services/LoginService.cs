using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace sahibinden_project;

public class LoginService : ILoginService
{
    private readonly SahibindenDbContext _db;

    public LoginService(SahibindenDbContext db)
    {
        _db = db;
    }

    public async Task LoginUser(LoginUser userDto)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == userDto.Username && u.Password == userDto.Password);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        else if (user.Username != userDto.Username || user.Password != userDto.Password)
        {
            throw new Exception("Invalid username or password");
        }
        else
        {
            Console.WriteLine("User logged in successfully");
        }
    }

}
