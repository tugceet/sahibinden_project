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
            var listings = new List<Listing>();

            var carListings = await _db.CarListings.ToListAsync();
            var propertyListings = await _db.PropertyListings.ToListAsync();
            var ikinciElListings = await _db.Ikinci_ElListings.ToListAsync();

            listings.AddRange(carListings);
            listings.AddRange(propertyListings);
            listings.AddRange(ikinciElListings);

            return listings;
        }

        public async Task<Listing> GetListing(int id)
        {
            var listing = await _db.Listings.FirstOrDefaultAsync(u => u.Id == id);
            if (listing == null)
            {
                throw new Exception("Null listing");
            }
            return listing;
        }

        public async Task<Listing> GetListing(string Category)
        {
            var listing = await _db.Listings.FirstOrDefaultAsync(u => u.Category == Category);
            if (listing == null)
            {
                throw new Exception("Null");
            }
            return listing;
        }

        public async Task<Listing> GetListingBrand(string Brand)
        {
            var listing = await _db.CarListings.FirstOrDefaultAsync(u => u.Brand == Brand);
            if (listing == null)
            {
                throw new Exception("Null");
            }
            return listing;
        }
   
    }
}
