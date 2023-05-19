using FluentValidation;

namespace DE.Application.DrillBlocks.Commands.CreateDrillBlock;

public sealed class CreateDrillBlockCommandValidator : AbstractValidator<CreateDrillBlockCommand>
{
    public CreateDrillBlockCommandValidator()
    {
        RuleFor(command => command.Name).NotEmpty();
    }
}
