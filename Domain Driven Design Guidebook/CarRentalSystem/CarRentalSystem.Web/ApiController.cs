namespace CarRentalSystem.Web;

using CarRentalSystem.Application;
using CarRentalSystem.Web.Common;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

[ApiController]
[Route("[controller]")]
public abstract class ApiController : ControllerBase
{
    private IMediator? mediator;

    protected IMediator Mediator
#pragma warning disable CS8603 // Possible null reference return.
        => this.mediator ??= this.HttpContext
            .RequestServices
            .GetService<IMediator>();
#pragma warning restore CS8603 // Possible null reference return.

    protected Task<ActionResult> Send(IRequest<Result> request)
        => this.Mediator.Send(request).ToActionResult();

    protected Task<ActionResult<TResult>> Send<TResult>(IRequest<TResult> request)
        => this.Mediator.Send(request).ToActionResult();

    protected Task<ActionResult<TResult>> Send<TResult>(IRequest<Result<TResult>> request)
        => this.Mediator.Send(request).ToActionResult();
}
