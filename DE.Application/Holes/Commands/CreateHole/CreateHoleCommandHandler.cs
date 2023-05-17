using MediatR;
using DE.Domain.Models;
using DE.Application.Interfaces;
using DE.Application.Common.Exceptions;

namespace DE.Application.Holes.Commands.CreateHole;

internal sealed class CreateHoleCommandHandler : IRequestHandler<CreateHoleCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateHoleCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Guid> Handle(CreateHoleCommand request, CancellationToken cancellationToken)
    {
        var drillBlock = await _dbContext.DrillBlocks.FindAsync(new object[] { request.DrillBlockId }, cancellationToken);
        if (drillBlock is null)
        {
            throw new NotFoundException(nameof(DrillBlock), request.DrillBlockId);
        }

        var hole = new Hole
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Depth = request.Depth,
            DrillBlockId = request.DrillBlockId
        };

        await _dbContext.Holes.AddAsync(hole, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return hole.Id;
    }
}
