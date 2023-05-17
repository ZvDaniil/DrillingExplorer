using MediatR;
using DE.Domain.Models;
using DE.Application.Interfaces;

namespace DE.Application.DrillBlocks.Commands.CreateDrillBlock;

internal sealed class CreateDrillBlockCommandHandler : IRequestHandler<CreateDrillBlockCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateDrillBlockCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Guid> Handle(CreateDrillBlockCommand request, CancellationToken cancellationToken)
    {
        var drillBlock = new DrillBlock
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            UpdateDate = null,
        };

        await _dbContext.DrillBlocks.AddAsync(drillBlock, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return drillBlock.Id;
    }
}
