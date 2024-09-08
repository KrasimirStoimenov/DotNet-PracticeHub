namespace CarRentalSystem.Application.Features.Identity.Commands.LoginUser.Models;

public class LoginOutputModel
{
    public LoginOutputModel(string token)
        => Token = token;

    public string Token { get; }
}
