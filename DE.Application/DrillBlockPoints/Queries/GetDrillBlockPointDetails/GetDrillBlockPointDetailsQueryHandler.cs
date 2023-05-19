using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DE.Domain.Models;
using DE.Application.Interfaces;
using DE.Application.Common.Exceptions;
using DE.Application.DrillBlockPoints.ViewModels;

namespace DE.Application.DrillBlockPoints.Queries.GetDrillBlockPointDetails;

internal sealed class GetDrillBlockPointDetailsQueryHandler
    : IQueryHandler<GetDrillBlockPointDetailsQuery, DrillBlockPointDetailsVm>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetDrillBlockPointDetailsQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<DrillBlockPointDetailsVm> Handle(GetDrillBlockPointDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.DrillBlockPoints
            .AsNoTracking()
            .IgnoreAutoIncludes()
            .Include(p => p.DrillBlock)
            .FirstOrDefaultAsync(p => p.Id == request.PointId, cancellationToken);

        if (entity is null || entity.DrillBlockId != request.DrillBlockId)
        {
            throw new NotFoundException(nameof(DrillBlockPoint));
        }

        return _mapper.Map<DrillBlockPointDetailsVm>(entity);
    }
}