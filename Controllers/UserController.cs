using Microsoft.AspNetCore.Mvc;
using sahibinden_project.Services;
namespace sahibinden_project.DTOs;

[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly IRegisterService _registerService;
    private readonly ILoginService _loginService;
    private readonly IListService _listService;
    private readonly IDeleteService _deleteService;
    
    

    public UserController(IRegisterService registerService, ILoginService loginService, IListService listService, IDeleteService deleteService
       )
    {
        _registerService = registerService;
        _loginService = loginService;
        _listService = listService;
        _deleteService = deleteService;
       
    }

    [HttpPost()]
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

    [HttpPost()]
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

    [HttpGet()]
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

    [HttpGet("id/{id}")]
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

    [HttpGet("username/{username}")]
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

    [HttpGet()]
    public async Task<IActionResult> Clean()
    {
        try
        {
            await _deleteService.Clean();
            return Ok("Database cleaned");
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete("id/{id}")]
    public async Task<IActionResult> DeleteUserById(int id)
    {
        try
        {
        await _deleteService.DeleteUserById(id);
        return Ok($"User with ID {id} deleted successfully.");
        }
        catch (Exception e)
        {
        return StatusCode(500, e.Message);
        }
    }

    [HttpDelete("username/{username}")]
    public async Task<IActionResult> DeleteUserByUsername(string username)
    {
        try
        {
            await _deleteService.DeleteUserByUsername(username);
            return Ok($"User with username {username} deleted successfully.");
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

}
