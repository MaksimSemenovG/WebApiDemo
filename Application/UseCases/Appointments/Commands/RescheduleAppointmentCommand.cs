using Core.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.Appointments.Commands;

public class RescheduleAppointmentCommand : IRequest
{
    public int AppointmentId { get; set; }
    public DateTime NewDate { get; set; }

    public RescheduleAppointmentCommand(int appointmentId, DateTime newDate)
    {
        AppointmentId = appointmentId;
        NewDate = newDate;
    }
}

public class RescheduleAppointmentCommandHandler : IRequestHandler<RescheduleAppointmentCommand>
{
    private readonly IAppointmentRepository _appointmentRepository;

    public RescheduleAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task Handle(RescheduleAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(request.AppointmentId);
        if (appointment is null)
        {
            throw new ArgumentException("Appointment not found");
        }

        appointment.Reschedule(request.NewDate);
        await _appointmentRepository.UpdateAsync(appointment);
    }
}
