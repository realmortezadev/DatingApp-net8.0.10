using API.Data;
using API.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // /api/users


public class UsersController(DataContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUsers>>> GetUsers()
    {
        Console.WriteLine("Its Already did this");
        var users = await context.Users.ToListAsync();
        return users;
    }
    

    [HttpGet("{id:int}")] // /api/users/2
    public async Task<ActionResult<AppUsers>> FindUsers(int id)
    {
        var user = await context.Users.FindAsync(id);
        if(user ==null) return NotFound();

        return user;
    }
}

