using Microsoft.AspNetCore.Mvc;
using TetPee.Service.Identity;

namespace TestRepo.Api.Controller;

[ApiController]
[Route("[controller]")]
public class IdentityController: ControllerBase
{
    private readonly IService _service;
    public IdentityController(IService service)
    {
        _service = service;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(Request.LoginRequest loginRequest)
    {
        var newUser = await _service.Login(loginRequest);
        return Ok(newUser);
    }
}