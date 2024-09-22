using Application.UseCases.Appointments.Commands;
using Application.UseCases.Appointments.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AppointmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAppointmentCommand command)
    {
        var appointmentId = await _mediator.Send(command);
        return Ok(appointmentId);
    }

    [HttpGet("therapist/{therapistId}")]
    public async Task<IActionResult> GetByTherapistId(int therapistId)
    {
        var appointments = await _mediator.Send(new GetAppointmentsByTherapistIdQuery { TherapistId = therapistId });
        return Ok(appointments);
    }

    [HttpPatch("{id}/complete")]
    public async Task<IActionResult> CompleteAppointment(int id)
    {
        await _mediator.Send(new CompleteAppointmentCommand(id));
        return Ok();
    }

    [HttpPatch("{id}/cancel")]
    public async Task<IActionResult> CancelAppointment(int id)
    {
        await _mediator.Send(new CancelAppointmentCommand(id));
        return Ok();
    }

    [HttpPatch("{id}/reschedule")]
    public async Task<IActionResult> RescheduleAppointment(int id, [FromBody] RescheduleAppointmentCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
}
