namespace crypto_stocks.Controllers;

using Microsoft.AspNetCore.Mvc;
using crypto_stocks.DTO;
using crypto_stocks.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using crypto_stocks.Services;
using crypto_stocks.Helpers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{

    private readonly IAuthService authService;
    public AuthController(
        IAuthService authService
    )
    {
        this.authService = authService;
    }


    [HttpPost("login")]
    public async Task<ActionResult<string>> Login([FromBody] LoginDTO user)
    {
        var token = await authService.Authenticate(user.Email, user.Password);
        if (token == null) return Unauthorized("Invalid credentials");

        return Ok(token);
    }

    [HttpPost("register")]

    public async Task<ActionResult<string>> Register([FromBody] RegisterDTO user)
    {
        try
        {

            var newUser = await authService.Register(user);

            var token = await authService.Authenticate(user.Email, user.Password);

            if (token == null) return Unauthorized("Invalid credentials");

            return Ok(token);
        }
        catch (ServiceException e)
        {
            return BadRequest(e.Message);
        }
    }


    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet("user")]
    public ActionResult<User> GetUser([FromHeader] string authorization)
    {
        try
        {
            var user = authService.GetUserFromRequest(HttpContext);
            return Ok(user);
        }
        catch (ServiceException e)
        {
            return NotFound(e.Message);
        }
    }
}