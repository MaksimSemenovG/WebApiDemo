using Core.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.Appointments.Commands;

public class CancelAppointmentCommand : IRequest
{
    public int AppointmentId { get; set; }

    public CancelAppointmentCommand(int appointmentId)
    {
        AppointmentId = appointmentId;
    }
}

public class CancelAppointmentCommandHandler : IRequestHandler<CancelAppointmentCommand>
{
    private readonly IAppointmentRepository _appointmentRepository;

    public CancelAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task Handle(CancelAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(request.AppointmentId);

        if (appointment is null)
        {
            throw new ArgumentException("Appointment not found");
        }

        appointment.Cancel();
        await _appointmentRepository.UpdateAsync(appointment);
    }
}
