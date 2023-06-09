﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using DE.Application.Interfaces;
using DE.Application.DrillBlocks.ViewModels;

namespace DE.Application.DrillBlocks.Queries.GetDrillBlocks;

internal sealed class GetDrillBlocksQueryHandler : IQueryHandler<GetDrillBlocksQuery, DrillBlockListVm>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetDrillBlocksQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<DrillBlockListVm> Handle(GetDrillBlocksQuery request, CancellationToken cancellationToken)
    {
        var drillBlocks = await _dbContext.DrillBlocks
            .AsNoTracking()
            .IgnoreAutoIncludes()
            .ProjectTo<DrillBlockLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new DrillBlockListVm { DrillBlocks = drillBlocks };
    }
}