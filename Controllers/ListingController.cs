using Microsoft.AspNetCore.Mvc;
using sahibinden_project.DTOs;
using sahibinden_project.Services;

namespace sahibinden_project;

[ApiController]
[Route("[controller]")]
public class ListingController : ControllerBase
{

    private readonly ISaveListingService _savelistingservice;
    private readonly IGetListingsService _getlistingsservice;
    private readonly IUpdateListingService _updatelistingsservice;
    private readonly IDeleteService _deletelistingsservice;

    public ListingController(ISaveListingService savelistingservice, IGetListingsService getlistingsservice, IUpdateListingService updateListingService, IDeleteService deleteService)
    {
        _savelistingservice = savelistingservice;
        _getlistingsservice = getlistingsservice;
        _updatelistingsservice = updateListingService;
        _deletelistingsservice = deleteService;
    }

    
    [HttpPost("savecar")]
    public async Task<IActionResult> SaveListingCar([FromBody] CarListing carListing)
    {
        if (carListing == null)
        {
            return BadRequest("Invalid listing data");
        }

        if (string.IsNullOrEmpty(carListing.Category) ||
            carListing.Category != "Araba" ||
            string.IsNullOrEmpty(carListing.Title) ||
            string.IsNullOrEmpty(carListing.Description) ||
            string.IsNullOrEmpty(carListing.Date.ToString()) ||
            carListing.Price < 0 ||
            string.IsNullOrEmpty(carListing.ImageFileName) ||
            string.IsNullOrEmpty(carListing.Brand) ||
            string.IsNullOrEmpty(carListing.Model) ||
            carListing.Year <= 0||
            carListing.Km <= 0||
            string.IsNullOrEmpty(carListing.Color) ||
            string.IsNullOrEmpty(carListing.FuelType) ||
            string.IsNullOrEmpty(carListing.GearType) ||
            carListing.EngineSize <= 0||
            carListing.HorsePower <= 0
            )
        {
            return BadRequest("Required data is missing");
        }

        try
        {
            await _savelistingservice.SaveListingCar(carListing);
            return Ok("Listing saved successfully.");
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost("saveproperty")]
    public async Task<IActionResult> SaveListingProperty([FromBody] PropertyListing propertyListing)
    {
        if (propertyListing == null)
        {
            return BadRequest("Invalid listing data");
        }

        if (string.IsNullOrEmpty(propertyListing.Category) ||
            propertyListing.Category != "Emlak" ||
            string.IsNullOrEmpty(propertyListing.Title) ||
            string.IsNullOrEmpty(propertyListing.Description) ||
            string.IsNullOrEmpty(propertyListing.Date.ToString()) ||
            propertyListing.Price < 0 ||
            string.IsNullOrEmpty(propertyListing.ImageFileName) ||
            propertyListing.M2 < 0 ||
            propertyListing.RoomCount < 0 ||
            string.IsNullOrEmpty(propertyListing.Location) ||
            string.IsNullOrEmpty(propertyListing.Status) ||
            propertyListing.Age <= 0 ||
            propertyListing.Floor == null ||
            string.IsNullOrEmpty(propertyListing.HeatingType) ||
            string.IsNullOrEmpty(propertyListing.BuildingType)
            )
        {
            return BadRequest("Required data is missing");

        }

        try
        {
            await _savelistingservice.SaveListingProperty(propertyListing);
            return Ok("Listing saved successfully.");
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost("saveikinciel")]
    public async Task<IActionResult> SaveListingIkinci_El([FromBody] Ikinci_ElListing ikinci_ElListing)
    {
        if (ikinci_ElListing == null)
        {
            return BadRequest("Invalid listing data");
        }

        if (string.IsNullOrEmpty(ikinci_ElListing.Category) ||
            ikinci_ElListing.Category != "İkinci El" ||
            string.IsNullOrEmpty(ikinci_ElListing.Title) ||
            string.IsNullOrEmpty(ikinci_ElListing.Description) ||
            string.IsNullOrEmpty(ikinci_ElListing.Date.ToString()) ||
            ikinci_ElListing.Price < 0 ||
            string.IsNullOrEmpty(ikinci_ElListing.ImageFileName) ||
            string.IsNullOrEmpty(ikinci_ElListing.Type) ||
            string.IsNullOrEmpty(ikinci_ElListing.Brand) ||
            string.IsNullOrEmpty(ikinci_ElListing.Condition)
            )
        {
            return BadRequest("Required data is missing");
        }

        try
        {
            await _savelistingservice.SaveListingIkinci_El(ikinci_ElListing);
            return Ok("Listing saved successfully.");
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
 
    [HttpPost("filter")]
    public async Task<IActionResult> PropertyListings([FromBody] PropertyFilter filter)
    {
        var listings = await _getlistingsservice.PropertyListings(filter);
        return Ok(listings);
    }

    [HttpPost("filtercars")]
    public async Task<IActionResult> CarListings([FromBody] CarFilter filter)
    {
        var listings = await _getlistingsservice.CarListings(filter);
        return Ok(listings);
    }
    [HttpPost("filterikinciel")]
    public async Task<IActionResult> Ikinci_ElListings([FromBody] Ikinci_ElFilter filter)
    {
        var listings = await _getlistingsservice.Ikinci_ElListings(filter);
        return Ok(listings);
    }

    [HttpGet()]
    public async Task<IActionResult> GetListings()
    {
        try
        {
            return Ok(await _getlistingsservice.GetListings()); 
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }   

    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetListing(int id)
    {
        try
        {
            return Ok(await _getlistingsservice.GetListing(id));
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("category/{category}")]
    public async Task<IActionResult> GetListing(string Category)
    {
        try
        {
            return Ok(await _getlistingsservice.GetListing(Category));
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete("id/{id}")]
    public async Task<IActionResult> DeleteListingById(int id)
    {
        try
        {
            await _deletelistingsservice.DeleteListingById(id);
            return Ok($"Listing with ID {id} deleted successfully.");
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPut("id/{id}")]
    public async Task<IActionResult> UpdateListing(int id, [FromBody] SaveListing updatedListing)
    {
        if (updatedListing == null)
        {
            return BadRequest("Invalid listing data");
        }

        if (string.IsNullOrEmpty(updatedListing.Category) ||
            string.IsNullOrEmpty(updatedListing.Title) ||
            string.IsNullOrEmpty(updatedListing.Description) ||
            string.IsNullOrEmpty(updatedListing.Date.ToString()) ||
            updatedListing.Price < 0 ||
            string.IsNullOrEmpty(updatedListing.ImageFileName))
        {
            return BadRequest("Required data is missing");
        }

        try
        {
            await _updatelistingsservice.UpdateListing(id, updatedListing);
            return Ok($"Listing with ID {id} updated successfully.");
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("brand/{brand}")]
    public async Task<IActionResult> GetListingBrand(string Brand)
    {
        try
        {
            return Ok(await _getlistingsservice.GetListingBrand(Brand));
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }


}
