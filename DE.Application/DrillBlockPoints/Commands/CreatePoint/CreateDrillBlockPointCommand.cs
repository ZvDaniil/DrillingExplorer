using MediatR;

namespace DE.Application.DrillBlockPoints.Commands.CreatePoint;

public record CreateDrillBlockPointCommand : IRequest<Guid>
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
    public Guid DrillBlockId { get; set; }
}