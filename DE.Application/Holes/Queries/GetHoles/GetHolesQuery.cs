using DE.Application.Interfaces;
using DE.Application.Holes.ViewModels;

namespace DE.Application.Holes.Queries.GetHoles;

public record GetHolesQuery : IQuery<HoleListVm>;