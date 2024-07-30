using System.ComponentModel.DataAnnotations;

namespace sahibinden_project;

public record class User
{
    [Key]
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? PhoneNumber { get; set; }
    public List<Listing>? Listings { get; set; }
    public bool IsAdmin { get; set; }
}
