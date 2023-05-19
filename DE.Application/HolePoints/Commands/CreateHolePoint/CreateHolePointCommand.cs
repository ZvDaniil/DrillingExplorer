using DE.Application.Interfaces;

namespace DE.Application.HolePoints.Commands.CreateHolePoint;

public record CreateHolePointCommand : ICommand<Guid>
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
    public Guid HoleId { get; set; }
}