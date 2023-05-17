using MediatR;
using Microsoft.EntityFrameworkCore;
using DE.Domain.Models;
using DE.Application.Interfaces;
using DE.Application.Common.Exceptions;
using DE.Application.DrillBlockPoints.ViewModels;

namespace DE.Application.DrillBlockPoints.Queries.GetDrillBlockPoints;

internal sealed class GetDrillBlockPointsQueryHandler : IRequestHandler<GetDrillBlockPointsQuery, IEnumerable<DrillBlockPointDto>>
{
    private readonly IApplicationDbContext _dbContext;

    public GetDrillBlockPointsQueryHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<IEnumerable<DrillBlockPointDto>> Handle(GetDrillBlockPointsQuery request, CancellationToken cancellationToken)
    {
        var drillBlock = await _dbContext.DrillBlocks
            .AsNoTracking()
            .Include(b => b.DrillBlockPoints)
            .FirstOrDefaultAsync(b => b.Id == request.DrillBlockId, cancellationToken);

        if (drillBlock is null)
        {
            throw new NotFoundException(nameof(DrillBlock), request.DrillBlockId);
        }

        var drillBlockPoints = drillBlock.DrillBlockPoints
            .OrderBy(p => p.Sequence)
            .Select(p => new DrillBlockPointDto
            {
                Id = p.Id,
                Sequence = p.Sequence,
                X = p.X,
                Y = p.Y,
                Z = p.Z
            });

        return drillBlockPoints;
    }
}