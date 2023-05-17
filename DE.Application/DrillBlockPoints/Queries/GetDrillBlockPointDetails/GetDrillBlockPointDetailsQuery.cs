using MediatR;
using DE.Application.DrillBlockPoints.ViewModels;

namespace DE.Application.DrillBlockPoints.Queries.GetDrillBlockPointDetails;

public record GetDrillBlockPointDetailsQuery(Guid Id) : IRequest<DrillBlockPointDetailsVm>;