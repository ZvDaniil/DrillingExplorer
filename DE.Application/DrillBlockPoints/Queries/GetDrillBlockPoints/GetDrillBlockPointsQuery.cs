using DE.Application.Interfaces;
using DE.Application.DrillBlockPoints.ViewModels;

namespace DE.Application.DrillBlockPoints.Queries.GetDrillBlockPoints;

public record GetDrillBlockPointsQuery(Guid DrillBlockId) : IQuery<IEnumerable<DrillBlockPointDto>>;