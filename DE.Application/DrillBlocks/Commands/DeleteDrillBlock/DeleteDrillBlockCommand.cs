using DE.Application.Interfaces;

namespace DE.Application.DrillBlocks.Commands.DeleteDrillBlock;

public record DeleteDrillBlockCommand(Guid Id) : ICommand;