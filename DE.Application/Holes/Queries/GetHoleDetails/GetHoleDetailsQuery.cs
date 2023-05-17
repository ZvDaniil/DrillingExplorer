using MediatR;
using DE.Application.Holes.ViewModels;

namespace DE.Application.Holes.Queries.GetHoleDetails;

public record GetHoleDetailsQuery(Guid Id) : IRequest<HoleDetailsVm>;