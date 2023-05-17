using MediatR;
using DE.Application.DrillBlocks.ViewModels;

namespace DE.Application.DrillBlocks.Queries.GetDrillBlocks;

public record GetDrillBlocksQuery : IRequest<DrillBlockListVm>;