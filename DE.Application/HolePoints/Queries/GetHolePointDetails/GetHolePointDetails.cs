using MediatR;
using DE.Application.HolePoints.ViewModels;

namespace DE.Application.HolePoints.Queries.GetHolePointDetails;

public record GetHolePointDetails(Guid HolePointId) : IRequest<HolePointDetailsVm>;