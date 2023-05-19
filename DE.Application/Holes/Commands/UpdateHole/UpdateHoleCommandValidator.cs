using FluentValidation;

namespace DE.Application.Holes.Commands.UpdateHole;

public sealed class UpdateHoleCommandValidator : AbstractValidator<UpdateHoleCommand>
{
    public UpdateHoleCommandValidator()
    {
        RuleFor(command => command.Id).NotEqual(Guid.Empty);
        RuleFor(command => command.Name).NotEmpty();
        RuleFor(command => command.Depth).GreaterThanOrEqualTo(0);
    }
}