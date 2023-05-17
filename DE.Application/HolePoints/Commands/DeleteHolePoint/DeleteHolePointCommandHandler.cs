using MediatR;
using DE.Domain.Models;
using DE.Application.Interfaces;
using DE.Application.Common.Exceptions;

namespace DE.Application.HolePoints.Commands.DeleteHolePoint;

internal sealed class DeleteHolePointCommandHandler : IRequestHandler<DeleteHolePointCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public DeleteHolePointCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task Handle(DeleteHolePointCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.HolePoints.FindAsync(new object[] { request.HolePointId }, cancellationToken);
        if (entity is null)
        {
            throw new NotFoundException(nameof(HolePoint), request.HolePointId);
        }

        _dbContext.HolePoints.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}