using MediatR;
using Microsoft.EntityFrameworkCore;
using DE.Application.Interfaces;
using DE.Application.Holes.ViewModels;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace DE.Application.Holes.Queries.GetHoles;

internal sealed class GetHolesQueryHandler : IRequestHandler<GetHolesQuery, HoleListVm>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetHolesQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<HoleListVm> Handle(GetHolesQuery request, CancellationToken cancellationToken)
    {
        var holes = await _dbContext.Holes
            .AsNoTracking()
            .IgnoreAutoIncludes()
            .ProjectTo<HoleLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new HoleListVm { Holes = holes };
    }
}
