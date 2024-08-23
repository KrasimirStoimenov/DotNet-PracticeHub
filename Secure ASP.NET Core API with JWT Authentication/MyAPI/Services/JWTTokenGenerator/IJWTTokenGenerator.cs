namespace MyAPI.Services.JWTTokenGenerator;

using Microsoft.AspNetCore.Identity;

public interface IJWTTokenGenerator
{
    public string GenerateJWTToken(IdentityUser user);
}
