using sahibinden_project.DTOs;

namespace sahibinden_project.Services
{
    public interface IGetListingsService
    {
        public Task<List<Listing>> GetListings();
        public Task<Listing> GetListing(int id);
        public Task<List<Listing>> GetListings(string Category);
        public Task<Listing> GetListingBrand(string Brand);
        public Task<List<PropertyListing>> PropertyListings(PropertyFilter filter);
        public Task<List<CarListing>> CarListings(CarFilter filter);
        public Task<List<Ikinci_ElListing>> Ikinci_ElListings(Ikinci_ElFilter filter);
    }
}
