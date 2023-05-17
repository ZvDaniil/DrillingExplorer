using MediatR;
using DE.Domain.Models;
using DE.Application.Interfaces;
using DE.Application.Common.Exceptions;

namespace DE.Application.HolePoints.Commands.UpdateHolePoint;

internal sealed class UpdateHolePointCommandHandler : IRequestHandler<UpdateHolePointCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateHolePointCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task Handle(UpdateHolePointCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.HolePoints.FindAsync(new object[] { request.HolePointId }, cancellationToken);
        if (entity is null)
        {
            throw new NotFoundException(nameof(HolePoint), request.HolePointId);
        }

        entity.X = request.X;
        entity.Y = request.Y;
        entity.Z = request.Z;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}