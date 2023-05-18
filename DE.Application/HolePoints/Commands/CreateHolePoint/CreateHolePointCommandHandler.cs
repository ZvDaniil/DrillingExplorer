using MediatR;
using Microsoft.EntityFrameworkCore;
using DE.Domain.Models;
using DE.Application.Interfaces;
using DE.Application.Common.Exceptions;

namespace DE.Application.HolePoints.Commands.CreateHolePoint;

internal sealed class CreateHolePointCommandHandler : IRequestHandler<CreateHolePointCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateHolePointCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Guid> Handle(CreateHolePointCommand request, CancellationToken cancellationToken)
    {
        var hole = await _dbContext.Holes.FirstOrDefaultAsync(h => h.Id == request.HoleId, cancellationToken);

        if (hole is null)
        {
            throw new NotFoundException(nameof(Hole), request.HoleId);
        }

        if (hole.HolePoint is not null)
        {
            throw new InvalidOperationException("Point already exists for the specified hole.");
        }

        var point = new HolePoint
        {
            Id = Guid.NewGuid(),
            X = request.X,
            Y = request.Y,
            Z = request.Z,
            HoleId = request.HoleId,
            Hole = hole
        };

        await _dbContext.HolePoints.AddAsync(point, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return point.Id;
    }
}
