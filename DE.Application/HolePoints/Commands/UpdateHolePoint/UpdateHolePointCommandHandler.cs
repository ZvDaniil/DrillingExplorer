using Microsoft.EntityFrameworkCore;
using DE.Domain.Models;
using DE.Application.Interfaces;
using DE.Application.Common.Exceptions;

namespace DE.Application.HolePoints.Commands.UpdateHolePoint;

internal sealed class UpdateHolePointCommandHandler : ICommandHandler<UpdateHolePointCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateHolePointCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task Handle(UpdateHolePointCommand request, CancellationToken cancellationToken)
    {
        var hole = await _dbContext.Holes.FirstOrDefaultAsync(h => h.Id == request.HoleId, cancellationToken);

        if (hole is null)
        {
            throw new NotFoundException(nameof(Hole), request.HoleId);
        }

        if (hole.HolePoint is null)
        {
            throw new NotFoundException(nameof(HolePoint));
        }

        hole.HolePoint.X = request.X;
        hole.HolePoint.Y = request.Y;
        hole.HolePoint.Z = request.Z;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
