using MediatR;
using DE.Application.DrillBlockPoints.ViewModels;

namespace DE.Application.DrillBlockPoints.Queries.GetDrillBlockPointDetails;

public record GetDrillBlockPointDetailsQuery(Guid DrillBlockId, Guid PointId) : IRequest<DrillBlockPointDetailsVm>;