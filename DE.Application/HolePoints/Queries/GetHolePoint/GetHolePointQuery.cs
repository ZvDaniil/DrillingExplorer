using MediatR;
using DE.Application.HolePoints.ViewModels;

namespace DE.Application.HolePoints.Queries.GetHolePoint;

public record GetHolePointQuery(Guid HoleId) : IRequest<HolePointDto>;