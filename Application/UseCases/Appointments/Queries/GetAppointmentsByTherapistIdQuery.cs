using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.Appointments.Queries;

public class GetAppointmentsByTherapistIdQuery : IRequest<List<Appointment>>
{
    public int TherapistId { get; set; }
}

public class GetAppointmentsByTherapistIdQueryHandler : IRequestHandler<GetAppointmentsByTherapistIdQuery, List<Appointment>>
{
    private readonly IAppointmentRepository _appointmentRepository;

    public GetAppointmentsByTherapistIdQueryHandler(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<List<Appointment>> Handle(GetAppointmentsByTherapistIdQuery request, CancellationToken cancellationToken)
    {
        return await _appointmentRepository.GetByTherapistIdAsync(request.TherapistId);
    }
}