using MediatR;
using Microsoft.EntityFrameworkCore;
using DE.Domain.Models;
using DE.Application.Interfaces;
using DE.Application.Common.Exceptions;
using DE.Application.HolePoints.ViewModels;

namespace DE.Application.HolePoints.Queries.GetHolePoint;

internal sealed record GetHolePointQueryHandler : IRequestHandler<GetHolePointQuery, HolePointDto>
{
    private readonly IApplicationDbContext _dbContext;

    public GetHolePointQueryHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<HolePointDto> Handle(GetHolePointQuery request, CancellationToken cancellationToken)
    {
        var hole = await _dbContext.Holes
           .AsNoTracking()
           .Include(h => h.HolePoint)
           .FirstOrDefaultAsync(h => h.Id == request.HoleId, cancellationToken);

        if (hole is null)
        {
            throw new NotFoundException(nameof(Hole), request.HoleId);
        }

        var holePointDto = new HolePointDto
        {
            Id = hole.Id,
            X = hole.HolePoint.X,
            Y = hole.HolePoint.Y,
            Z = hole.HolePoint.Z
        };

        return holePointDto;
    }
}
