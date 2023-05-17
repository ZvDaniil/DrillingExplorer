using MediatR;

namespace DE.Application.HolePoints.Commands.UpdateHolePoint;

public record UpdateHolePointCommand(double X, double Y, double Z, Guid HolePointId) : IRequest;