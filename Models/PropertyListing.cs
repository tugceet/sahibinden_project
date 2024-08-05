using System.ComponentModel.DataAnnotations;


namespace sahibinden_project;

public class PropertyListing : Listing
{
    public int M2 { get; set; }
    public int RoomCount { get; set; }
    public int Age { get; set; }
    public string? HeatingType { get; set; }
    public string? BuildingType { get; set; }
    public int Floor { get; set; }
}
