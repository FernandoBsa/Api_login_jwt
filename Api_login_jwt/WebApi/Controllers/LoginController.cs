using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Services.Request;
using WebApi.Extensions;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : Controller
{
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost]
    public async Task<IResult> LoginAsync([FromBody] LoginRequest loginRequest)
    {
        var result = await _loginService.LoginAsync(loginRequest);
        
        return Results.Extensions.MapResult(result);
    }
}