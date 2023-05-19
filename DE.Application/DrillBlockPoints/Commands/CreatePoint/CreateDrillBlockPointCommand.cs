using DE.Application.Interfaces;

namespace DE.Application.DrillBlockPoints.Commands.CreatePoint;

public record CreateDrillBlockPointCommand : ICommand<Guid>
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
    public Guid DrillBlockId { get; set; }
}