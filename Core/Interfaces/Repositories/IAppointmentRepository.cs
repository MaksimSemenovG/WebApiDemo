using Core.Entities;

namespace Core.Interfaces.Repositories;

public interface IAppointmentRepository : IGenericRepository<Appointment>
{
    Task<List<Appointment>> GetByTherapistIdAsync(int therapistId);
}
