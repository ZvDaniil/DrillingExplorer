using MediatR;

namespace DE.Application.Holes.Commands.CreateHole;

public record CreateHoleCommand(string Name, double Depth, Guid DrillBlockId) : IRequest<Guid>;