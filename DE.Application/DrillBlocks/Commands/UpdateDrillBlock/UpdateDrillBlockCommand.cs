using MediatR;

namespace DE.Application.DrillBlocks.Commands.UpdateDrillBlock;

public record UpdateDrillBlockCommand(Guid Id, string Name) : IRequest;