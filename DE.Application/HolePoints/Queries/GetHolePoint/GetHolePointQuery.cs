using MediatR;
using DE.Application.HolePoints.ViewModels;

namespace DE.Application.HolePoints.Queries.GetHolePoints;

public record GetHolePointQuery(Guid HoleId) : IRequest<HolePointDto?>;