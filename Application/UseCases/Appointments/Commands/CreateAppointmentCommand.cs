using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.Appointments.Commands;


public class CreateAppointmentCommand : IRequest<int>
{
    public int TherapistId { get; set; }
    public string PatientName { get; set; }
    public DateTime AppointmentDate { get; set; }
}

public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, int>
{
    private readonly IAppointmentRepository _appointmentRepository;

    public CreateAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<int> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = new Appointment
        {
            TherapistId = request.TherapistId,
            PatientName = request.PatientName,
            AppointmentDate = request.AppointmentDate
        };

        await _appointmentRepository.AddAsync(appointment);
        return appointment.Id;
    }
}
