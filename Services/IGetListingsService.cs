namespace sahibinden_project.Services
{
    public interface IGetListingsService
    {
        public Task<List<Listing>> GetListings();
        public Task<Listing> GetListing(int id);
        public Task<Listing> GetListing(string Category);
        public Task DeleteListingById(int id);
        public Task UpdateListing(int id, SaveListing updatedListing);


    }
}
