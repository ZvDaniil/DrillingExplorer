using DE.Application.Interfaces;
using DE.Application.DrillBlockPoints.ViewModels;

namespace DE.Application.DrillBlockPoints.Queries.GetDrillBlockPointDetails;

public record GetDrillBlockPointDetailsQuery(Guid DrillBlockId, Guid PointId) : IQuery<DrillBlockPointDetailsVm>;