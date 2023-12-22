using Microsoft.AspNetCore.Mvc;
using REST_API.Data.Interfaces;
using REST_API.Data.Models;

namespace REST_API.Data.Controllers;

[Route("api/[controller]")]
public class UsersController : Controller
{
    private readonly IUser _userService;

    public UsersController(IUser userService)
    {
        _userService = userService;
    }

    
    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = _userService.AllUsers;

        if (users.ToList().Count > 0)
        {
            return Ok(users);
        }
        else
        {
            return NoContent();
        }
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] User? user)
    {
        if (user == null)
        {
            return BadRequest("Invalid user object");
        }

        var newUser = _userService.CreateUser(user);

        return CreatedAtAction("GetUsers", new { Id = newUser.Id }, newUser);
    }
}