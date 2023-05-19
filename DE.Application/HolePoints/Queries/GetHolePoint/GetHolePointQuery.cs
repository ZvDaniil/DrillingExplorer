using MediatR;
using DE.Application.HolePoints.ViewModels;
using DE.Application.Interfaces;

namespace DE.Application.HolePoints.Queries.GetHolePoints;

public record GetHolePointQuery(Guid HoleId) : IQuery<HolePointDto?>;