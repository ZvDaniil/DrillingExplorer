using DE.Application.Interfaces;

namespace DE.Application.DrillBlocks.Commands.CreateDrillBlock;

public record CreateDrillBlockCommand(string Name) : ICommand<Guid>;
