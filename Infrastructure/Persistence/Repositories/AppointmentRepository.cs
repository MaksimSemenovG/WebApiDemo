using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
{
    private readonly ApplicationDbContext _context;

    public AppointmentRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Appointment>> GetByTherapistIdAsync(int therapistId)
    {
        return await _context.Appointments
            .Where(a => a.TherapistId == therapistId)
            .Include(a => a.Therapist)
            .ToListAsync();
    }
}
