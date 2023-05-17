using MediatR;
using Microsoft.EntityFrameworkCore;
using DE.Domain.Models;
using DE.Application.Interfaces;
using DE.Application.Holes.ViewModels;
using DE.Application.Common.Exceptions;

namespace DE.Application.Holes.Queries.GetHoleDetails;

internal sealed class GetHoleDetailsQueryHandler : IRequestHandler<GetHoleDetailsQuery, HoleDetailsVm>
{
    private readonly IApplicationDbContext _dbContext;

    public GetHoleDetailsQueryHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<HoleDetailsVm> Handle(GetHoleDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Holes
            .AsNoTracking()
            .Include(h => h.DrillBlock)
            .Include(h => h.HolePoint)
            .Select(HoleExpressions.ToDetailsVm)
            .FirstOrDefaultAsync(h => h.Id == request.Id, cancellationToken);

        return entity ?? throw new NotFoundException(nameof(Hole), request.Id);
    }
}
