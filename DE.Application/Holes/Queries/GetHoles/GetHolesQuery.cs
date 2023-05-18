using MediatR;
using DE.Application.Holes.ViewModels;

namespace DE.Application.Holes.Queries.GetHoles;

public record GetHolesQuery : IRequest<HoleListVm>;