namespace CarRentalSystem.Web.Features
{
    using System.Threading.Tasks;

    using CarRentalSystem.Application.Features.Identity.Commands.LoginUser;
    using CarRentalSystem.Application.Features.Identity.Commands.LoginUser.Models;
    using CarRentalSystem.Application.Features.Identity.Commands.RegisterUser;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class IdentityController : ApiController
    {
        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterUserCommand registerCommand)
            => await this.Send(registerCommand);

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginOutputModel>> Login(LoginUserCommand loginCommand)
            => await this.Send(loginCommand);

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return this.Ok(this.HttpContext.User.Identity!.Name);
        }
    }
}
