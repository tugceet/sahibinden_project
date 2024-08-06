using Microsoft.EntityFrameworkCore;
using sahibinden_project.DTOs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public async Task<List<Listing>> GetListings(string Category)
        {
            return await _db.Listings
            .Where(u => u.Category == Category)
            .ToListAsync();
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
                query = query.Where(l => l.Status.Contains(filter.Location));

            if (!string.IsNullOrEmpty(filter.Location))
                query = query.Where(l => l.Location.Contains(filter.Location));

            if (filter.MinPrice.HasValue)
                query = query.Where(l => l.Price >= filter.MinPrice.Value && l.Price <= filter.MaxPrice);

            return await query.ToListAsync();
        }

        public async Task<List<CarListing>> CarListings(CarFilter filter)
        {
            var query = _db.CarListings.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Brand))
                query = query.Where(l => l.Brand == filter.Brand);

            if (!string.IsNullOrEmpty(filter.Model))
                query = query.Where(l => l.Model == filter.Model);

            if (filter.Year.HasValue)
                query = query.Where(l => l.Year == filter.Year.Value);

            if (filter.MinKm.HasValue)
                query = query.Where(l => l.Price >= filter.MinKm.Value && l.Price <= filter.MaxKm);

            if (!string.IsNullOrEmpty(filter.FuelType))
                query = query.Where(l => l.FuelType == filter.FuelType);

            if (!string.IsNullOrEmpty(filter.GearType))
                query = query.Where(l => l.GearType == filter.GearType);

            if (!string.IsNullOrEmpty(filter.Color))
                query = query.Where(l => l.Color == filter.Color);

            if (filter.MinPrice.HasValue)
                query = query.Where(l => l.Price >= filter.MinPrice.Value && l.Price <= filter.MaxPrice);

            if (!string.IsNullOrEmpty(filter.BodyType))
                query = query.Where(l => l.BodyType == filter.BodyType);

            return await query.ToListAsync();
        }

        public async Task<List<Ikinci_ElListing>> Ikinci_ElListings(Ikinci_ElFilter filter)
        {
            var query = _db.Ikinci_ElListings.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Title))
                query = query.Where(l => l.Title.Contains(filter.Title));

            if (!string.IsNullOrEmpty(filter.Description))
                query = query.Where(l => l.Description.Contains(filter.Description));

            if (!string.IsNullOrEmpty(filter.Category))
                query = query.Where(l => l.Category == filter.Category);

            if (filter.MinPrice.HasValue)
                query = query.Where(l => l.Price >= filter.MinPrice.Value && l.Price <= filter.MaxPrice);

            if (!string.IsNullOrEmpty(filter.Date))
                query = query.Where(l => l.Date == filter.Date);

            if (!string.IsNullOrEmpty(filter.Brand))
                query = query.Where(l => l.Brand == filter.Brand);

            if (!string.IsNullOrEmpty(filter.Type))
                query = query.Where(l => l.Type == filter.Type);

            if (!string.IsNullOrEmpty(filter.Condition))
                query = query.Where(l => l.Condition == filter.Condition);

            return await query.ToListAsync();
        }
    }    
}


