namespace MyAPI.Controllers;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using MyAPI.Models.Auth;
using MyAPI.Services.JWTTokenGenerator;

[ApiController]
[Route("api/[controller]")]
public class AuthController(UserManager<IdentityUser> userManager, IJWTTokenGenerator tokenGenerator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        var user = new IdentityUser
        {
            UserName = model.Username,
            Email = model.Email
        };

        var result = await userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            return this.Ok(new { message = "User registered successfully" });
        }

        return this.BadRequest(result.Errors);
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var user = await userManager.FindByNameAsync(model.Username);
        if (user is not null && await userManager.CheckPasswordAsync(user, model.Password))
        {
            var token = tokenGenerator.GenerateJWTToken(user);
            return this.Ok(new { token });
        }

        return Unauthorized();
    }
}
