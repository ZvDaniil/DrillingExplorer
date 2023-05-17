using MediatR;
using Microsoft.EntityFrameworkCore;
using DE.Domain.Models;
using DE.Application.Interfaces;
using DE.Application.Common.Exceptions;
using DE.Application.DrillBlocks.ViewModels;
using DE.Application.DrillBlockPoints.ViewModels;

namespace DE.Application.DrillBlockPoints.Queries.GetDrillBlockPointDetails;

internal sealed class GetDrillBlockPointDetailsQueryHandler
    : IRequestHandler<GetDrillBlockPointDetailsQuery, DrillBlockPointDetailsVm>
{
    private readonly IApplicationDbContext _dbContext;

    public GetDrillBlockPointDetailsQueryHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<DrillBlockPointDetailsVm> Handle(GetDrillBlockPointDetailsQuery request, CancellationToken cancellationToken)
    {
        var vm = await _dbContext.DrillBlockPoints
            .AsNoTracking()
            .Include(p => p.DrillBlock)
            .Select(p => new DrillBlockPointDetailsVm
            {
                Id = p.Id,
                Sequence = p.Sequence,
                X = p.X,
                Y = p.Y,
                Z = p.Z,

                DrillBlock = new DrillBlockLookupDto
                {
                    Id = p.DrillBlock.Id,
                    Name = p.DrillBlock.Name
                }
            })
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (vm is null)
        {
            throw new NotFoundException(nameof(DrillBlockPoint), request.Id);
        }

        return vm;
    }
}

