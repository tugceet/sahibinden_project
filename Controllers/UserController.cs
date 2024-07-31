using Microsoft.AspNetCore.Mvc;
namespace sahibinden_project.DTOs;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IRegisterService _registerService;
    private readonly ILoginService _loginService;
    private readonly IListService _listService;


    public UserController(IRegisterService registerService, ILoginService loginService, IListService listService)
    {
        _registerService = registerService;
        _loginService = loginService;
        _listService = listService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUser user)
    {
        if (user == null)
        {
            return BadRequest("Invalid user data");
        }

        if (string.IsNullOrEmpty(user.Email) ||
            string.IsNullOrEmpty(user.Password) ||
            string.IsNullOrEmpty(user.Name) ||
            string.IsNullOrEmpty(user.Surname) ||
            string.IsNullOrEmpty(user.PhoneNumber) ||
            string.IsNullOrEmpty(user.Username))
        {
            return BadRequest("Required data is missing");
        }

        try
        {
            await _registerService.RegisterUser(user);
            return Ok("User registered successfully" + user);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }

    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUser user)
    {
        if (user == null)
        {
            return BadRequest("Invalid user data");
        }

        if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
        {
            return BadRequest("Required data is missing");
        }

        try
        {
            await _loginService.LoginUser(user);
            return Ok("User logged in successfully");
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("list")]
    public async Task<IActionResult> List()
    {
        try
        {
            return Ok(await _listService.GetUsers());
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("list/id/{id}")]
    public async Task<IActionResult> List(int id)
    {
        try
        {
            return Ok(await _listService.GetUser(id));
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("list/username/{username}")]
    public async Task<IActionResult> List(string username)
    {
        try
        {
            return Ok(await _listService.GetUser(username));
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("clean")]
    public async Task<IActionResult> Clean()
    {
        try
        {
            await _listService.Clean();
            return Ok("Database cleaned");
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

}
