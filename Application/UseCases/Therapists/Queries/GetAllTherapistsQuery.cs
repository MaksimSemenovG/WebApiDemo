using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.Therapists.Queries;

public class GetAllTherapistsQuery : IRequest<List<Therapist>> { }

public class GetAllTherapistsQueryHandler : IRequestHandler<GetAllTherapistsQuery, List<Therapist>>
{
    private readonly ITherapistRepository _therapistRepository;

    public GetAllTherapistsQueryHandler(ITherapistRepository therapistRepository)
    {
        _therapistRepository = therapistRepository;
    }

    public async Task<List<Therapist>> Handle(GetAllTherapistsQuery request, CancellationToken cancellationToken)
    {
        return await _therapistRepository.GetAllAsync();
    }
}