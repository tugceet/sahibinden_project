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

        public async Task DeleteListingById(int id)
        {
            var listing = await _db.Listings.FindAsync(id);
            if (listing != null)
            {
                _db.Listings.Remove(listing);
                await _db.SaveChangesAsync();
            }
        }

        public async Task UpdateListing(int id, SaveListing updatedListing)
        {
            var listing = await _db.Listings.FindAsync(id);
            if (listing != null)
            {
                listing.Category = updatedListing.Category;
                listing.Title = updatedListing.Title;
                listing.Description = updatedListing.Description;
                listing.Date = updatedListing.Date;
                listing.Price = updatedListing.Price;
                listing.ImageFileName = updatedListing.ImageFileName;

                _db.Listings.Update(listing);
                await _db.SaveChangesAsync();
            }
        }
    }
}
