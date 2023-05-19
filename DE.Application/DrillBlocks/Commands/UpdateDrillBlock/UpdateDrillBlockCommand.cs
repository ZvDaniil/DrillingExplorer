using DE.Application.Interfaces;

namespace DE.Application.DrillBlocks.Commands.UpdateDrillBlock;

public record UpdateDrillBlockCommand(Guid Id, string Name) : ICommand;