using MediatR;
using Microsoft.EntityFrameworkCore;
using DE.Domain.Models;
using DE.Application.Interfaces;
using DE.Application.Common.Exceptions;

namespace DE.Application.DrillBlockPoints.Commands.CreatePoint;

internal sealed class CreateDrillBlockPointCommandHandler : IRequestHandler<CreateDrillBlockPointCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateDrillBlockPointCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Guid> Handle(CreateDrillBlockPointCommand request, CancellationToken cancellationToken)
    {
        var drillBlock = await _dbContext.DrillBlocks.FindAsync(new object[] { request.DrillBlockId }, cancellationToken);

        if (drillBlock is null)
        {
            throw new NotFoundException(nameof(DrillBlock), request.DrillBlockId);
        }

        var maxSequence = await GetMaxSequenceForBlock(drillBlock.Id, cancellationToken);

        var point = new DrillBlockPoint
        {
            Id = Guid.NewGuid(),
            Sequence = maxSequence + 1,
            X = request.X,
            Y = request.Y,
            Z = request.Z,
            DrillBlockId = request.DrillBlockId,
            DrillBlock = drillBlock
        };

        await _dbContext.DrillBlockPoints.AddAsync(point, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return point.Id;
    }

    private async Task<int> GetMaxSequenceForBlock(Guid drillBlockId, CancellationToken cancellationToken) =>
        await _dbContext.DrillBlockPoints
            .Where(p => p.DrillBlockId == drillBlockId)
            .Select(p => (int?)p.Sequence)
            .MaxAsync(cancellationToken) ?? 0;
}