using DE.Application.DrillBlocks.ViewModels;

namespace DE.Application.DrillBlockPoints.ViewModels;

public class DrillBlockPointDetailsVm
{
    public Guid Id { get; set; }

    public int Sequence { get; set; }

    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public DrillBlockLookupDto DrillBlock { get; set; } = default!;
}