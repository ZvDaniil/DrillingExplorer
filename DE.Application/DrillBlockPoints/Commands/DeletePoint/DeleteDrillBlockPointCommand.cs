using DE.Application.Interfaces;

namespace DE.Application.DrillBlockPoints.Commands.DeletePoint;

public record DeleteDrillBlockPointCommand(Guid DrillBlockId, Guid PointId) : ICommand;