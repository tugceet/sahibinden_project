using Microsoft.AspNetCore.Mvc;
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

    
    [HttpPost("save")]
    public async Task<IActionResult> SaveListing([FromBody] SaveListing listing)
    {
        if (listing == null)
        {
            return BadRequest("Invalid listing data");
        }

        if (string.IsNullOrEmpty(listing.Category) ||
            string.IsNullOrEmpty(listing.Title) ||
            string.IsNullOrEmpty(listing.Description) ||
            string.IsNullOrEmpty(listing.Date.ToString()) ||
            int.IsNegative(listing.Price) ||
            string.IsNullOrEmpty(listing.ImageFileName))
        {
            return BadRequest("Required data is missing");
        }

        try
        {
            await _savelistingservice.SaveListing(listing);
            return Ok("Listing saved successfully" + listing);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
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


}
