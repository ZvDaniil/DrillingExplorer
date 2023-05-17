using MediatR;
using Microsoft.EntityFrameworkCore;
using DE.Application.Interfaces;
using DE.Application.Holes.ViewModels;

namespace DE.Application.Holes.Queries.GetHoles;

internal sealed class GetHolesQueryHandler : IRequestHandler<GetHolesQuery, HoleListVm>
{
    private readonly IApplicationDbContext _dbContext;

    public GetHolesQueryHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<HoleListVm> Handle(GetHolesQuery request, CancellationToken cancellationToken)
    {
        var holesQuery = await _dbContext.Holes
            .AsNoTracking()
            .Where(h => h.DrillBlockId == request.DrillBlockId)
            .Select(HoleExpressions.ToLookupDto)
            .ToListAsync(cancellationToken);

        return new HoleListVm { Holes = holesQuery };
    }
}