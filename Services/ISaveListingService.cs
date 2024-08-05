namespace sahibinden_project;

public interface ISaveListingService
{
    public Task SaveListingCar(CarListing carListing);
    public Task SaveListinProperty(PropertyListing propertyListing);
    public Task SaveListingIkinci_El(Ikinci_ElListing ikinci_ElListing);
}
