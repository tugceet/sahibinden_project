using sahibinden_project.DTOs;

namespace sahibinden_project.Services
{
    public interface IGetListingsService
    {
        public Task<List<Listing>> GetListings();
        public Task<Listing> GetListing(int id);
        public Task<Listing> GetListing(string Category);
        public Task<Listing> GetListingBrand(string Brand);
        public Task<List<PropertyListing>> PropertyListings(PropertyFilter filter);
    }
}
