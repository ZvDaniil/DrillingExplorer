using MediatR;

namespace DE.Application.HolePoints.Commands.DeleteHolePoint;

public record DeleteHolePointCommand(Guid HolePointId) : IRequest;