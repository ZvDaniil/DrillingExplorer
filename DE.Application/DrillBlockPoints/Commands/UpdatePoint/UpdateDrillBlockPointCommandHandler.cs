using MediatR;
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
        var entity = await _dbContext.DrillBlockPoints.FindAsync(new object[] { request.Id }, cancellationToken);
        if (entity is null)
        {
            throw new NotFoundException(nameof(DrillBlockPoint), request.Id);
        }

        entity.X = request.X;
        entity.Y = request.Y;
        entity.Z = request.Z;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
