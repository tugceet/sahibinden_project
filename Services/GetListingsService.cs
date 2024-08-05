using Microsoft.EntityFrameworkCore;
using sahibinden_project.DTOs;

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

        public async Task<List<PropertyListing>> PropertyListings(PropertyFilter filter)
        {
            var query = _db.PropertyListings.AsQueryable();

            if (filter.M2.HasValue)
                query = query.Where(l => l.M2 == filter.M2.Value);

            if (filter.RoomCount.HasValue)
                query = query.Where(l => l.RoomCount == filter.RoomCount.Value);

            if (filter.Age.HasValue)
                query = query.Where(l => l.Age == filter.Age.Value);

            if (!string.IsNullOrEmpty(filter.HeatingType))
                query = query.Where(l => l.HeatingType == filter.HeatingType);

            if (!string.IsNullOrEmpty(filter.BuildingType))
                query = query.Where(l => l.BuildingType == filter.BuildingType);

            if (filter.Floor.HasValue)
                query = query.Where(l => l.Floor == filter.Floor.Value);

            if (!string.IsNullOrEmpty(filter.Status))
                query = query.Where(l => l.Status == filter.Status);

            if (!string.IsNullOrEmpty(filter.Location))
                query = query.Where(l => l.Location.Contains(filter.Location));

            if (filter.MinPrice.HasValue)
                query = query.Where(l => l.Price >= filter.MinPrice.Value && l.Price <= filter.MaxPrice);

            return await query.ToListAsync();
        }





    }    
}


