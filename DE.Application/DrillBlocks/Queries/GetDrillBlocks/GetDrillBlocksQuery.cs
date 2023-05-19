using DE.Application.Interfaces;
using DE.Application.DrillBlocks.ViewModels;

namespace DE.Application.DrillBlocks.Queries.GetDrillBlocks;

public record GetDrillBlocksQuery : IQuery<DrillBlockListVm>;