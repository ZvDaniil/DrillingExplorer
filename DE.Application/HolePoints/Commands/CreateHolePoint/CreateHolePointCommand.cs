using MediatR;

namespace DE.Application.HolePoints.Commands.CreateHolePoint;

public record CreateHolePointCommand : IRequest<Guid>
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
    public Guid HoleId { get; set; }
}