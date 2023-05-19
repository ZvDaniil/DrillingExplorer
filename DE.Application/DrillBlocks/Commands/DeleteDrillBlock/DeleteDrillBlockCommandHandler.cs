using DE.Domain.Models;
using DE.Application.Interfaces;
using DE.Application.Common.Exceptions;

namespace DE.Application.DrillBlocks.Commands.DeleteDrillBlock;

internal sealed class DeleteDrillBlockCommandHandler : ICommandHandler<DeleteDrillBlockCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public DeleteDrillBlockCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task Handle(DeleteDrillBlockCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.DrillBlocks.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity is null)
        {
            throw new NotFoundException(nameof(DrillBlock), request.Id);
        }

        _dbContext.DrillBlocks.Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}