namespace CarRentalSystem.Application.Features.Identity.Commands.RegisterUser;

using System.Threading;
using System.Threading.Tasks;

using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Application.Features.Identity;

using MediatR;

public class RegisterUserCommand : UserInputModel, IRequest<Result>
{
    public RegisterUserCommand(string email, string password)
        : base(email, password)
    {
    }

    public class RegisterUserCommandHandler(IIdentity identity) : IRequestHandler<RegisterUserCommand, Result>
    {
        public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            => await identity.Register(request);
    }
}
