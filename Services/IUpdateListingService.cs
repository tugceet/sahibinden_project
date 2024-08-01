namespace sahibinden_project.Services
{
    public interface IUpdateListingService
    {
        public Task UpdateListing(int id, SaveListing updatedListing);
    }

}
