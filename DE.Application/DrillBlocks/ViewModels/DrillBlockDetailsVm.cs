using DE.Application.Holes.ViewModels;
using DE.Application.DrillBlockPoints.ViewModels;

namespace DE.Application.DrillBlocks.ViewModels;

public class DrillBlockDetailsVm
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime? UpdateDate { get; set; }
    public IEnumerable<HoleLookupDto>? Holes { get; set; }
    public IEnumerable<DrillBlockPointDto>? DrillBlockPoints { get; set; }
}