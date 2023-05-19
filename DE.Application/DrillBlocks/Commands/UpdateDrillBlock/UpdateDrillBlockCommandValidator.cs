using FluentValidation;

namespace DE.Application.DrillBlocks.Commands.UpdateDrillBlock;

public sealed class UpdateDrillBlockCommandValidator : AbstractValidator<UpdateDrillBlockCommand>
{
    public UpdateDrillBlockCommandValidator()
    {
        RuleFor(command => command.Id).NotEqual(Guid.Empty);
        RuleFor(command => command.Name).NotEmpty();
    }
}
