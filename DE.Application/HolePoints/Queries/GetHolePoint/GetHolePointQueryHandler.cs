using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DE.Domain.Models;
using DE.Application.Interfaces;
using DE.Application.Common.Exceptions;
using DE.Application.HolePoints.ViewModels;

namespace DE.Application.HolePoints.Queries.GetHolePoints;

internal sealed class GetHolePointQueryHandler : IQueryHandler<GetHolePointQuery, HolePointDto?>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetHolePointQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<HolePointDto?> Handle(GetHolePointQuery request, CancellationToken cancellationToken)
    {
        var hole = await _dbContext.Holes.FirstOrDefaultAsync(h => h.Id == request.HoleId, cancellationToken);

        if (hole is null)
        {
            throw new NotFoundException(nameof(Hole), request.HoleId);
        }

        return hole.HolePoint is null ? null : _mapper.Map<HolePointDto>(hole.HolePoint);
    }
}