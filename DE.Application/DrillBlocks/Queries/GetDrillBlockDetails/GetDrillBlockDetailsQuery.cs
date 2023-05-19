using DE.Application.Interfaces;
using DE.Application.DrillBlocks.ViewModels;

namespace DE.Application.DrillBlocks.Queries.GetDrillBlockDetails;

public record GetDrillBlockDetailsQuery(Guid Id) : IQuery<DrillBlockDetailsVm>;