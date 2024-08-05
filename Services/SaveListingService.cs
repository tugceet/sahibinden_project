namespace sahibinden_project;

public class SaveListingService : ISaveListingService
{
    private readonly SahibindenDbContext _db;

    public SaveListingService(SahibindenDbContext db)
    {
        _db = db;
    }


    public async Task SaveListingCar(CarListing carListing)
    {
        _db.CarListings.Add(carListing);
        await _db.SaveChangesAsync();
    }

    public async Task SaveListingProperty(PropertyListing propertyListing)
    {
        _db.PropertyListings.Add(propertyListing);
        await _db.SaveChangesAsync();
    }

    public async Task SaveListingIkinci_El(Ikinci_ElListing ikinci_ElListing)
    {
        _db.Ikinci_ElListings.Add(ikinci_ElListing);
        await _db.SaveChangesAsync();
    }

}

