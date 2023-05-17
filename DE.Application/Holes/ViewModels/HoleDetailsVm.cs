using DE.Application.DrillBlocks.ViewModels;
using DE.Application.HolePoints.ViewModels;

namespace DE.Application.Holes.ViewModels;

public class HoleDetailsVm
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Depth { get; set; }
    public DrillBlockLookupDto DrillBlock { get; set; } = null!;
    public HolePointDto? HolePoint { get; set; }
}