using MediatR;
using Microsoft.EntityFrameworkCore;
using DE.Domain.Models;
using DE.Application.Interfaces;
using DE.Application.Common.Exceptions;
using DE.Application.DrillBlocks.ViewModels;

namespace DE.Application.DrillBlocks.Queries.GetDrillBlockDetails;

internal sealed class GetDrillBlockDetailsQueryHandler : IRequestHandler<GetDrillBlockDetailsQuery, DrillBlockDetailsVm>
{
    private readonly IApplicationDbContext _dbContext;

    public GetDrillBlockDetailsQueryHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<DrillBlockDetailsVm> Handle(GetDrillBlockDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.DrillBlocks
            .AsNoTracking()
            .Include(b => b.Holes)
            .Include(b => b.DrillBlockPoints)
            .Select(DrillBlockExpressions.ToDetailsVm)
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        return entity ?? throw new NotFoundException(nameof(DrillBlock), request.Id);
    }
}