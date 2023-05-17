using MediatR;
using Microsoft.EntityFrameworkCore;
using DE.Application.Interfaces;
using DE.Application.DrillBlocks.ViewModels;

namespace DE.Application.DrillBlocks.Queries.GetDrillBlocks;

internal sealed class GetDrillBlocksQueryHandler : IRequestHandler<GetDrillBlocksQuery, DrillBlockListVm>
{
    private readonly IApplicationDbContext _dbContext;

    public GetDrillBlocksQueryHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<DrillBlockListVm> Handle(GetDrillBlocksQuery request, CancellationToken cancellationToken)
    {
        var drillBlockQuery = await _dbContext.DrillBlocks
            .AsNoTracking()
            .Select(DrillBlockExpressions.ToLookupDto)
            .ToListAsync(cancellationToken);

        return new DrillBlockListVm { DrillBlocks = drillBlockQuery };
    }
}