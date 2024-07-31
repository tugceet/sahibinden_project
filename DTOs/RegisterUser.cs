namespace sahibinden_project;

public record class RegisterUser
{
    public string Email { get; init; }
    public string Password { get; init; }
    public string Name { get; init; }
    public string Surname { get; init; }
    public string PhoneNumber { get; init; }
    public string Username { get; init; }

    public RegisterUser(string email, string password, string name, string surname, string phoneNumber, string username)
    {
        Email = email;
        Password = password;
        Name = name;
        Surname = surname;
        PhoneNumber = phoneNumber;
        Username = username;
    }
}
