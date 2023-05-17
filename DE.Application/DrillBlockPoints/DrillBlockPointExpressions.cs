using DE.Application.DrillBlockPoints.ViewModels;
using DE.Application.DrillBlocks.ViewModels;
using DE.Domain.Models;
using System.Linq.Expressions;

namespace DE.Application.DrillBlockPoints;

internal static class DrillBlockPointExpressions
{
    public static Expression<Func<DrillBlockPoint, DrillBlockPointDetailsVm>> ToDetailsVm =>
        x => new DrillBlockPointDetailsVm
        {
            Id = x.Id,
            Sequence = x.Sequence,
            X = x.X,
            Y = x.Y,
            Z = x.Z,
            DrillBlock = new DrillBlockLookupDto
            {
                Id = x.DrillBlockId,
                Name = x.DrillBlock.Name
            }
        };
}
