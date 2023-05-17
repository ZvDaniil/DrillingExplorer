using MediatR;

namespace DE.Application.DrillBlockPoints.Commands.DeletePoint;

public record DeleteDrillBlockPointCommand(Guid DrillBlockPointId) : IRequest;