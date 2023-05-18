using MediatR;
using DE.Domain.Models;
using DE.Application.Interfaces;
using DE.Application.Common.Exceptions;

namespace DE.Application.DrillBlocks.Commands.UpdateDrillBlock;

internal sealed class UpdateDrillBlockCommandHandler : IRequestHandler<UpdateDrillBlockCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateDrillBlockCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task Handle(UpdateDrillBlockCommand request, CancellationToken cancellationToken)
    {
        var drillBlock = await _dbContext.DrillBlocks.FindAsync(new object[] { request.Id }, cancellationToken);

        if (drillBlock is null)
        {
            throw new NotFoundException(nameof(DrillBlock), request.Id);
        }

        drillBlock.Name = request.Name;
        drillBlock.UpdateDate = DateTime.Now;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
