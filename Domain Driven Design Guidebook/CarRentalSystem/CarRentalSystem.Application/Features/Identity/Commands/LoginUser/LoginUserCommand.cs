namespace CarRentalSystem.Application.Features.Identity.Commands.LoginUser;

using System.Threading;
using System.Threading.Tasks;

using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Application.Features.Identity;
using CarRentalSystem.Application.Features.Identity.Commands.LoginUser.Models;

using MediatR;

public class LoginUserCommand : UserInputModel, IRequest<Result<LoginOutputModel>>
{
    public LoginUserCommand(string email, string password)
        : base(email, password)
    {
    }

    public class LoginUserCommandHandler(IIdentity identity) : IRequestHandler<LoginUserCommand, Result<LoginOutputModel>>
    {
        public async Task<Result<LoginOutputModel>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            => await identity.Login(request);
    }
}
