using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using DE.Application.Interfaces;
using DE.Application.DrillBlockPoints.ViewModels;

namespace DE.Application.DrillBlockPoints.Queries.GetDrillBlockPoints;

internal sealed class GetDrillBlockPointsQueryHandler
    : IQueryHandler<GetDrillBlockPointsQuery, IEnumerable<DrillBlockPointDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetDrillBlockPointsQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<IEnumerable<DrillBlockPointDto>> Handle(GetDrillBlockPointsQuery request,
        CancellationToken cancellationToken) =>
         await _dbContext.DrillBlockPoints
            .AsNoTracking()
            .Where(p => p.DrillBlockId == request.DrillBlockId)
            .ProjectTo<DrillBlockPointDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
}