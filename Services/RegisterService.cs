using Microsoft.EntityFrameworkCore;

namespace sahibinden_project;

public class RegisterService : IRegisterService
{
    private readonly SahibindenDbContext _db;

    public RegisterService(SahibindenDbContext db)
    {
        _db = db;
    }

    public async Task RegisterUser(RegisterUser userDto)
    {
        // şifre hasleme uygulanabilir.

        var user = new User
        {
            Email = userDto.Email,
            Password = userDto.Password,
            Name = userDto.Name,
            Surname = userDto.Surname,
            PhoneNumber = userDto.PhoneNumber,
            Username = userDto.Username
        };

        if (await _db.Users.AnyAsync(u => u.Username == user.Username))
        {
            throw new Exception("Username already exists");
        }

        _db.Users.Add(user);
        await _db.SaveChangesAsync();
    }

    
}
