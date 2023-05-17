using System.Linq.Expressions;
using DE.Domain.Models;
using DE.Application.Holes.ViewModels;
using DE.Application.DrillBlocks.ViewModels;
using DE.Application.DrillBlockPoints.ViewModels;

namespace DE.Application.DrillBlocks;

internal static class DrillBlockExpressions
{
    public static Expression<Func<DrillBlock, DrillBlockLookupDto>> ToLookupDto =>
        x => new DrillBlockLookupDto
        {
            Id = x.Id,
            Name = x.Name,
        };

    public static Expression<Func<DrillBlock, DrillBlockDetailsVm>> ToDetailsVm =>
        x => new DrillBlockDetailsVm
        {
            Id = x.Id,
            Name = x.Name,

            Holes = x.Holes == null
                ? new List<HoleLookupDto>()
                : x.Holes.Select(h => new HoleLookupDto
                {
                    Id = h.Id,
                    Name = h.Name,
                }),

            DrillBlockPoints = x.DrillBlockPoints == null
                ? new List<DrillBlockPointDto>()
                : x.DrillBlockPoints.Select(p => new DrillBlockPointDto
                {
                    Id = p.Id,
                    Sequence = p.Sequence,
                    X = p.X,
                    Y = p.Y,
                    Z = p.Z
                })
        };
}
