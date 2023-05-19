using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DE.Domain.Models;
using DE.Application.Interfaces;
using DE.Application.Common.Exceptions;
using DE.Application.DrillBlocks.ViewModels;

namespace DE.Application.DrillBlocks.Queries.GetDrillBlockDetails;

internal sealed class GetDrillBlockDetailsQueryHandler : IQueryHandler<GetDrillBlockDetailsQuery, DrillBlockDetailsVm>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetDrillBlockDetailsQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<DrillBlockDetailsVm> Handle(GetDrillBlockDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.DrillBlocks
            .AsNoTracking()
            .IgnoreAutoIncludes()
            .Include(b => b.Holes)
            .Include(b => b.DrillBlockPoints)
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (entity is null)
        {
            throw new NotFoundException(nameof(DrillBlock), request.Id);
        }

        return _mapper.Map<DrillBlockDetailsVm>(entity);
    }
}