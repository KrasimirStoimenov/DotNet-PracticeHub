using CarRentalSystem.Application.Features.Identity;

namespace CarRentalSystem.Application.Contracts;

using CarRentalSystem.Application.Features.Identity.Commands.LoginUser.Models;

public interface IIdentity
{
    Task<Result> Register(UserInputModel userInput);

    Task<Result<LoginOutputModel>> Login(UserInputModel userInput);
}
