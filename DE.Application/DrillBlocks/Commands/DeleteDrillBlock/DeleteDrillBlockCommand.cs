using MediatR;

namespace DE.Application.DrillBlocks.Commands.DeleteDrillBlock;

public record DeleteDrillBlockCommand(Guid Id) : IRequest;