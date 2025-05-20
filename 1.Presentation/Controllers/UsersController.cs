using _2.BusinessLayer;
using _3.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace _1.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UsersBL _usersBl;

    public UsersController(UsersBL usersBl)
    {
        _usersBl = usersBl;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var users = await _usersBl.GetAllAsync();
        return Ok(users);
    }
    
    [HttpPost]
    public IActionResult CreateUser([FromForm] users? user)
    {
        var created = _usersBl.CreateUser(user);
        
        if (user == null)
        {
            return BadRequest("User cannot be null");
        }

        if (created)
        {
            return Ok(new { message = "Usuario creado exitosamente", user });
        }
        
        return BadRequest("Ha ocurrido un error al crear un usuario");
    }
}