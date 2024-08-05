using Microsoft.EntityFrameworkCore;

namespace sahibinden_project.Services
{
    public class DeleteService : IDeleteService
    {
        private readonly SahibindenDbContext _db;

        public DeleteService(SahibindenDbContext db)
        {
            _db = db;
        }

        public async Task DeleteListingById(int id)
        {
            var listing = await _db.Listings.FindAsync(id);
            if (listing != null)
            {
                _db.Listings.Remove(listing);
                await _db.SaveChangesAsync();
            }
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


}
