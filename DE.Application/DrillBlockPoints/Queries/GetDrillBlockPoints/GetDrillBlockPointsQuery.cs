using MediatR;
using DE.Application.DrillBlockPoints.ViewModels;

namespace DE.Application.DrillBlockPoints.Queries.GetDrillBlockPoints;

public record GetDrillBlockPointsQuery(Guid DrillBlockId) : IRequest<IEnumerable<DrillBlockPointDto>>;