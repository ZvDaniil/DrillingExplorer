using MediatR;
using DE.Domain.Models;
using DE.Application.Interfaces;
using DE.Application.Common.Exceptions;

namespace DE.Application.Holes.Commands.DeleteHole;

internal sealed class DeleteHoleCommandHandler : IRequestHandler<DeleteHoleCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public DeleteHoleCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task Handle(DeleteHoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Holes.FindAsync(new object[] { request.Id }, cancellationToken);
        if (entity is null)
        {
            throw new NotFoundException(nameof(Hole), request.Id);
        }

        _dbContext.Holes.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}