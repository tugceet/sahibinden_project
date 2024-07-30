using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace sahibinden_project;

public record class User
{
    [Key]
    public int Id { get; set; }
    public string Username { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string Name { get; set; } = String.Empty;
    public string Surname { get; set; } = String.Empty;
    public string PhoneNumber { get; set; } = String.Empty;
    public List<Listing>? Listings { get; set; }
    public bool IsAdmin { get; set; }
}
