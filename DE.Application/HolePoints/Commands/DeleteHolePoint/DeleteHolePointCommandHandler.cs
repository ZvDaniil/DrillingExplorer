using MediatR;
using Microsoft.EntityFrameworkCore;
using DE.Domain.Models;
using DE.Application.Interfaces;
using DE.Application.Common.Exceptions;

namespace DE.Application.HolePoints.Commands.DeleteHolePoint;

internal sealed class DeleteHolePointCommandHandler : IRequestHandler<DeleteHolePointCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public DeleteHolePointCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task Handle(DeleteHolePointCommand request, CancellationToken cancellationToken)
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

        _dbContext.HolePoints.Remove(hole.HolePoint);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}