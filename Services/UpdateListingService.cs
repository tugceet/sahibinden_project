namespace sahibinden_project.Services
{
    public class UpdateListingService
    {

        private readonly SahibindenDbContext _db;

        public UpdateListingService(SahibindenDbContext db)
        {
            _db = db;
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
