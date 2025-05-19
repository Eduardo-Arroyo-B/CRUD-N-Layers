using _2.BusinessLayer;
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
}