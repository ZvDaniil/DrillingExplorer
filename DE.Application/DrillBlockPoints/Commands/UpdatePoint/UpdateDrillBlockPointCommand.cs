using MediatR;

namespace DE.Application.DrillBlockPoints.Commands.UpdatePoint;

public record UpdateDrillBlockPointCommand : IRequest
{
    public Guid DrillBlockId { get; set; }
    public Guid PointId { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
}