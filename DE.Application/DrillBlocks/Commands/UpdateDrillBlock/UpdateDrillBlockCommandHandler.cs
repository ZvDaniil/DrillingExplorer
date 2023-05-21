using DE.Domain.Models;
using DE.Application.Interfaces;
using DE.Application.Common.Exceptions;

namespace DE.Application.DrillBlocks.Commands.UpdateDrillBlock;

internal sealed class UpdateDrillBlockCommandHandler : ICommandHandler<UpdateDrillBlockCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateDrillBlockCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task Handle(UpdateDrillBlockCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.DrillBlocks.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity is null)
        {
            throw new NotFoundException(nameof(DrillBlock), request.Id);
        }

        entity.Name = request.Name;
        entity.UpdateDate = DateTime.Now;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
