using MediatR;

namespace DE.Application.HolePoints.Commands.UpdateHolePoint;

public record UpdateHolePointCommand : IRequest
{
    public Guid HoleId { get; set; }

    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
}