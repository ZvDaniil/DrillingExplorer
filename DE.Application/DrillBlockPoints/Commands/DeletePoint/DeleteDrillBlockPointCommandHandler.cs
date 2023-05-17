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
        var entity = await _dbContext.DrillBlockPoints.FindAsync(new object?[] { request.DrillBlockPointId }, cancellationToken);
        if (entity is null)
        {
            throw new NotFoundException(nameof(DrillBlockPoint), request.DrillBlockPointId);
        }

        _dbContext.DrillBlockPoints.Remove(entity);

        //Not tested
        var remainingPoints = await _dbContext.DrillBlockPoints
            .Where(p => p.DrillBlockId == entity.DrillBlockId && p.Sequence > entity.Sequence)
            .ExecuteUpdateAsync(s => s.SetProperty(p => p.Sequence, p => p.Sequence - 1), cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}