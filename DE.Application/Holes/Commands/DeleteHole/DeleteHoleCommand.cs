using MediatR;

namespace DE.Application.Holes.Commands.DeleteHole;

public record DeleteHoleCommand(Guid Id) : IRequest;