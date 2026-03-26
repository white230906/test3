using Microsoft.AspNetCore.Mvc;
using TetPee.Service.User;

namespace TestRepo.Api.Controller;

[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase
{
    private readonly IService _userService;
    public  UserController(IService userService)
    {
        _userService = userService;
    }
    [HttpPost("")]
    public async Task<IActionResult> CreateUser(Request.UserRequest request)
    {
        var newCategory = await _userService.CreateUser(request);
        return Ok(newCategory);
    }
    [HttpGet("")]
    public async Task<IActionResult> ListUsers(string? searchTerm, int pageIndex = 1, int pageSize = 10)
    {
        var newCategory = await _userService.ListUsers(searchTerm, pageIndex, pageSize);
        return Ok(newCategory);
    }
}