using MediatR;

namespace DE.Application.DrillBlocks.Commands.CreateDrillBlock;

public record CreateDrillBlockCommand(string Name) : IRequest<Guid>;
