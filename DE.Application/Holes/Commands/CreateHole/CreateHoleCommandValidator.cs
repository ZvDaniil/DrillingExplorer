using FluentValidation;

namespace DE.Application.Holes.Commands.CreateHole;

public sealed class CreateHoleCommandValidator : AbstractValidator<CreateHoleCommand>
{
    public CreateHoleCommandValidator()
    {
        RuleFor(command => command.DrillBlockId).NotEqual(Guid.Empty);
        RuleFor(command => command.Name).NotEmpty();
        RuleFor(command => command.Depth).GreaterThanOrEqualTo(0);
    }
}
