using MediatR;
using DE.Domain.Models;
using DE.Application.Interfaces;
using DE.Application.Common.Exceptions;

namespace DE.Application.Holes.Commands.UpdateHole;

internal sealed class UpdateHoleCommandHandler : IRequestHandler<UpdateHoleCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateHoleCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task Handle(UpdateHoleCommand request, CancellationToken cancellationToken)
    {
        var hole = await _dbContext.Holes.FindAsync(new object[] { request.Id }, cancellationToken);
        if (hole is null)
        {
            throw new NotFoundException(nameof(Hole), request.Id);
        }

        hole.Name = request.Name;
        hole.Depth = request.Depth;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
