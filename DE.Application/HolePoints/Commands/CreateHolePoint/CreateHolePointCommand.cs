using MediatR;

namespace DE.Application.HolePoints.Commands.CreateHolePoint;

public record CreateHolePointCommand(double X, double Y, double Z, Guid HoleId) : IRequest<Guid>;