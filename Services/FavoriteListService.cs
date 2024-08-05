using Microsoft.EntityFrameworkCore;

namespace sahibinden_project.Services
{
    public class FavoriteListService : IFavoriteListService
    {
        private readonly SahibindenDbContext _db;

        public FavoriteListService(SahibindenDbContext db)
        {
            _db = db;
        }

    

        public async Task AddFavorite(int userId, int listingId)
        {
            var user = await _db.Users.FindAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (user.Favorites == null)
            {
                user.Favorites = new List<int>();
            }

            if (!user.Favorites.Contains(listingId))
            {
                user.Favorites.Add(listingId);
                await _db.SaveChangesAsync();
            }
        }

        public async Task RemoveFavorite(int userId, int listingId)
        {
            var user = await _db.Users.FindAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (user.Favorites != null && user.Favorites.Contains(listingId))
            {
                user.Favorites.Remove(listingId);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<int>> GetFavorites(int userId)
        {
            var user = await _db.Users.FindAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user.Favorites ?? new List<int>();
        }
    }
}


