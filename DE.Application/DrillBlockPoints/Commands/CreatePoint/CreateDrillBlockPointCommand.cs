using MediatR;

namespace DE.Application.DrillBlockPoints.Commands.CreatePoint;

public record CreateDrillBlockPointCommand(double X, double Y, double Z, Guid DrillBlockId) : IRequest<Guid>;