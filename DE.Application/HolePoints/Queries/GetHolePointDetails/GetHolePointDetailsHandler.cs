using MediatR;
using Microsoft.EntityFrameworkCore;
using DE.Domain.Models;
using DE.Application.Interfaces;
using DE.Application.Common.Exceptions;
using DE.Application.Holes.ViewModels;
using DE.Application.HolePoints.ViewModels;

namespace DE.Application.HolePoints.Queries.GetHolePointDetails;

internal sealed class GetHolePointDetailsHandler : IRequestHandler<GetHolePointDetails, HolePointDetailsVm>
{
    private readonly IApplicationDbContext _dbContext;

    public GetHolePointDetailsHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<HolePointDetailsVm> Handle(GetHolePointDetails request, CancellationToken cancellationToken)
    {
        var holePointDetailsVm = await _dbContext.HolePoints
            .AsNoTracking()
            .Include(p => p.Hole)
            .Select(p => new HolePointDetailsVm
            {
                Id = p.Id,
                X = p.X,
                Y = p.Y,
                Z = p.Z,
                Hole = new HoleLookupDto
                {
                    Id = p.HoleId,
                    Name = p.Hole.Name
                }
            })
            .FirstOrDefaultAsync(p => p.Id == request.HolePointId, cancellationToken);

        return holePointDetailsVm ?? throw new NotFoundException(nameof(HolePoint), request.HolePointId);
    }
}