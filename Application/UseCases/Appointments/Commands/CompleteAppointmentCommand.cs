using Application.Events;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.Appointments.Commands;

public class CompleteAppointmentCommand : IRequest
{
    public int AppointmentId { get; set; }

    public CompleteAppointmentCommand(int appointmentId)
    {
        AppointmentId = appointmentId;
    }
}

public class CompleteAppointmentCommandHandler : IRequestHandler<CompleteAppointmentCommand>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMediator _mediator;

    public CompleteAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMediator mediator)
    {
        _appointmentRepository = appointmentRepository;
        _mediator = mediator;
    }

    public async Task Handle(CompleteAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(request.AppointmentId);

        if (appointment is null)
        {
            throw new ArgumentException("Appointment not found");
        }

        appointment.MarkAsCompleted();
        await _appointmentRepository.UpdateAsync(appointment);

        // Publish event to handle side effects (Emails, Events, InApp notifications, etc.)
        await _mediator.Publish(new AppointmentCompletedEvent(appointment), cancellationToken);
    }
}


