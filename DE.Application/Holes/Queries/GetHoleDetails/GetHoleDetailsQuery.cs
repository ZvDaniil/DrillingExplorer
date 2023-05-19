using DE.Application.Interfaces;
using DE.Application.Holes.ViewModels;

namespace DE.Application.Holes.Queries.GetHoleDetails;

public record GetHoleDetailsQuery(Guid Id) : IQuery<HoleDetailsVm>;