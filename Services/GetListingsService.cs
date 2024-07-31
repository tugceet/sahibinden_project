using Microsoft.EntityFrameworkCore;

namespace sahibinden_project.Services
{
    public class GetListingsService: IGetListingsService
    {
        private readonly SahibindenDbContext _db;

        public GetListingsService(SahibindenDbContext db)
        {
            _db = db;
        }

        public async Task<List<Listing>> GetListings()
        {
            return await _db.Listings.ToListAsync();
        }

        public async Task<Listing> GetListing(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Listing> GetListing(string Category)
        {
            throw new NotImplementedException();
        }
    }
}
