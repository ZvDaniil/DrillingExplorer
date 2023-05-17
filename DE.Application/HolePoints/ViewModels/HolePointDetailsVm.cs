using DE.Application.Holes.ViewModels;

namespace DE.Application.HolePoints.ViewModels;

public class HolePointDetailsVm
{
    public Guid Id { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public HoleLookupDto Hole { get; set; } = default!;
}