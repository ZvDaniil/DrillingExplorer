using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DE.Domain.Models;
using DE.Application.Interfaces;
using DE.Application.Holes.ViewModels;
using DE.Application.Common.Exceptions;

namespace DE.Application.Holes.Queries.GetHoleDetails;

internal sealed class GetHoleDetailsQueryHandler : IQueryHandler<GetHoleDetailsQuery, HoleDetailsVm>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetHoleDetailsQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<HoleDetailsVm> Handle(GetHoleDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Holes
            .AsNoTracking()
            .IgnoreAutoIncludes()
            .Include(h => h.DrillBlock)
            .FirstOrDefaultAsync(h => h.Id == request.Id, cancellationToken);

        if (entity is null)
        {
            throw new NotFoundException(nameof(Hole), request.Id);
        }

        return _mapper.Map<HoleDetailsVm>(entity);
    }
}
