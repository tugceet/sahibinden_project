

namespace sahibinden_project;

public class RegisterService : IRegisterService
{
    private readonly SahibindenDbContext _db;

    public RegisterService(SahibindenDbContext db)
    {
        db = _db;
    }

    public async void RegisterUser(User user)
    {
        // şifre hasleme uygulanabilir.

        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        
    }

    
}
