using Application.UseCases.Therapists.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TherapistsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TherapistsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var therapists = await _mediator.Send(new GetAllTherapistsQuery());
        return Ok(therapists);
    }
}
