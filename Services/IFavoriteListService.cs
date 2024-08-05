namespace sahibinden_project.Services
{
    public interface IFavoriteListService
    {
       
            Task AddFavorite(int userId, int listingId);
            Task RemoveFavorite(int userId, int listingId);
            Task<List<int>> GetFavorites(int userId);
        
    }
}
