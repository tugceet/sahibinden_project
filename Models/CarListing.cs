using System.ComponentModel.DataAnnotations;


namespace sahibinden_project;

public class CarListing : Listing
{
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public int Year { get; set; }
    public int Km { get; set; }
    public string? FuelType { get; set; }
    public string? GearType { get; set; }
    public int EngineSize { get; set; }
    public int HorsePower { get; set; }
    public string? Color { get; set; }
    public string? BodyType { get; set; }
    
}
