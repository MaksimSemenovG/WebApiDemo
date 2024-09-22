using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class TherapistRepository : GenericRepository<Therapist>, ITherapistRepository
{
    private readonly ApplicationDbContext _context;

    public TherapistRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}
