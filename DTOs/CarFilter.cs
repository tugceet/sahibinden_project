namespace sahibinden_project.DTOs
{
    public class CarFilter
    {
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int? Year { get; set; }
        public int? MinKm { get; set; }
        public int? MaxKm { get; set; }
        public string? FuelType { get; set; }
        public string? GearType { get; set; }
        public string? Color { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public string? BodyType { get; set; }
    }
}
