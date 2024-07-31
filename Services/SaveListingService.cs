namespace sahibinden_project;

public class SaveListingService : ISaveListingService
{
    private readonly SahibindenDbContext _db;

    public SaveListingService(SahibindenDbContext db)
    {
        _db = db;
    }


    public async Task SaveListing(SaveListing listingDto)
    {
        var listing = new Listing
        {
            Category = listingDto.Category,
            Title = listingDto.Title,
            Description = listingDto.Description,
            Price = listingDto.Price,
            Date = listingDto.Date,
            ImageFileName = listingDto.ImageFileName
        };

        _db.Listings.Add(listing);
        await _db.SaveChangesAsync();
    }

}

