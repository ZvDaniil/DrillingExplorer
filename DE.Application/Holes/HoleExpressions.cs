using System.Linq.Expressions;
using DE.Domain.Models;
using DE.Application.Holes.ViewModels;
using DE.Application.DrillBlocks.ViewModels;
using DE.Application.HolePoints.ViewModels;

namespace DE.Application.Holes;

internal static class HoleExpressions
{
    public static Expression<Func<Hole, HoleLookupDto>> ToLookupDto =>
        x => new HoleLookupDto
        {
            Id = x.Id,
            Name = x.Name
        };

    public static Expression<Func<Hole, HoleDetailsVm>> ToDetailsVm =>
        x => new HoleDetailsVm
        {
            Id = x.Id,
            Name = x.Name,
            Depth = x.Depth,
            DrillBlock = new DrillBlockLookupDto
            {
                Id = x.DrillBlockId,
                Name = x.DrillBlock.Name
            },
            HolePoint = new HolePointDto
            {
                Id = x.HolePointId,
                X = x.HolePoint.X,
                Y = x.HolePoint.Y,
                Z = x.HolePoint.Z
            }
        };
}
