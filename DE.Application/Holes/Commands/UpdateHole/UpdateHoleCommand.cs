using MediatR;

namespace DE.Application.Holes.Commands.UpdateHole;

public record UpdateHoleCommand(Guid Id, string Name, double Depth) : IRequest;