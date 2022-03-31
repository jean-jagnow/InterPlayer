using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Features.Common;

[Route("api/[controller]/[action]")]
[ApiController]
public abstract class FeatureController : ControllerBase
{
    protected readonly IMediator mediator;

    protected FeatureController(IMediator mediator)
    {
        this.mediator = mediator;
    }
}