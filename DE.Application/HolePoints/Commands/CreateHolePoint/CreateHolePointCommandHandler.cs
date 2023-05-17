using MediatR;
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
        var hole = await _dbContext.Holes.FindAsync(new object[] { request.HoleId }, cancellationToken);
        if (hole is null)
        {
            throw new NotFoundException(nameof(Hole), request.HoleId);
        }
        else if (hole.HolePoint is not null)
        {
            throw new InvalidOperationException("Hole already has a point.");
        }

        var holePoint = new HolePoint
        {
            Id = Guid.NewGuid(),
            X = request.X,
            Y = request.Y,
            Z = request.Z,
            HoleId = hole.Id
        };

        await _dbContext.HolePoints.AddAsync(holePoint, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return holePoint.Id;
    }
}