using MediatR;

namespace DE.Application.DrillBlockPoints.Commands.UpdatePoint;

public record UpdateDrillBlockPointCommand(Guid Id, double X, double Y, double Z) : IRequest;