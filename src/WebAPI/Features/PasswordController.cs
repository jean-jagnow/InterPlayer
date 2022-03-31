using InterPlayer.Application.Password;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Features.Common;

namespace WebAPI.Features;

public class PasswordController : FeatureController
{
    public PasswordController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [Produces(typeof(ValidatePasswordResult))]
    public async Task<IActionResult> Validate([FromForm] ValidatePasswordCommand command)
        => Ok(await mediator.Send(command));
}