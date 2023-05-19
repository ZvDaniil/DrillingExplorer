using FluentValidation;

namespace DE.Application.DrillBlocks.Commands.DeleteDrillBlock;

public sealed class DeleteDrillBlockCommandValidator : AbstractValidator<DeleteDrillBlockCommand>
{
    public DeleteDrillBlockCommandValidator()
    {
        RuleFor(command => command.Id).NotEqual(Guid.Empty);
    }
}
