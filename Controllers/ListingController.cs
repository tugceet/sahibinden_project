using Microsoft.AspNetCore.Mvc;
using sahibinden_project.Services;

namespace sahibinden_project;

[ApiController]
[Route("[controller]")]
public class ListingController : ControllerBase
{

    private readonly ISaveListingService _savelistingservice;
    private readonly IGetListingsService _getlistingsservice;

    public ListingController(ISaveListingService savelistingservice, IGetListingsService getlistingsservice)
    {
        _savelistingservice = savelistingservice;
        _getlistingsservice = getlistingsservice;
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
}
