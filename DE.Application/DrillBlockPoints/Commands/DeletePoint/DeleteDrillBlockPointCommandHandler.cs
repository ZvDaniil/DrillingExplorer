using MediatR;
using Microsoft.EntityFrameworkCore;
using DE.Domain.Models;
using DE.Application.Interfaces;
using DE.Application.Common.Exceptions;

namespace DE.Application.DrillBlockPoints.Commands.DeletePoint;

internal sealed class DeleteDrillBlockPointCommandHandler : IRequestHandler<DeleteDrillBlockPointCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public DeleteDrillBlockPointCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task Handle(DeleteDrillBlockPointCommand request, CancellationToken cancellationToken)
    {
        var point = await _dbContext.DrillBlockPoints.FindAsync(new object?[] { request.PointId }, cancellationToken);

        if (point is null || point.DrillBlockId != request.DrillBlockId)
        {
            throw new NotFoundException(nameof(DrillBlockPoint));
        }

        _dbContext.DrillBlockPoints.Remove(point);
        await UpdateBlockPointSequence(point.DrillBlockId, point.Sequence, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task UpdateBlockPointSequence(Guid drillBlockId, int startSequence, CancellationToken cancellationToken) =>
        await _dbContext.DrillBlockPoints
            .Where(p => p.DrillBlockId == drillBlockId && p.Sequence > startSequence)
            .ExecuteUpdateAsync(s => s.SetProperty(p => p.Sequence, p => p.Sequence - 1), cancellationToken);
}