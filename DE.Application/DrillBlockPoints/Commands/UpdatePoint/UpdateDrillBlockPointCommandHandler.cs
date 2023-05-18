using MediatR;
using Microsoft.EntityFrameworkCore;
using DE.Domain.Models;
using DE.Application.Interfaces;
using DE.Application.Common.Exceptions;

namespace DE.Application.DrillBlockPoints.Commands.UpdatePoint;

internal sealed class UpdateDrillBlockPointCommandHandler : IRequestHandler<UpdateDrillBlockPointCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateDrillBlockPointCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task Handle(UpdateDrillBlockPointCommand request, CancellationToken cancellationToken)
    {
        var point = await _dbContext.DrillBlockPoints.FindAsync(new object?[] { request.PointId }, cancellationToken);

        if (point is null || point.DrillBlockId != request.DrillBlockId)
        {
            throw new NotFoundException(nameof(DrillBlockPoint));
        }

        point.X = request.X;
        point.Y = request.Y;
        point.Z = request.Z;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
