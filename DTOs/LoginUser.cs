namespace sahibinden_project;

public record class LoginUser
{
    public string Username { get; set; }
    public string Password { get; set; }

    public LoginUser(string password, string username)
    {
        Password = password;
        Username = username;
    }
}
