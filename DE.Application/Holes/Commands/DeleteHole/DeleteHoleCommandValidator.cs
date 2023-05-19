using FluentValidation;

namespace DE.Application.Holes.Commands.DeleteHole;

public sealed class DeleteHoleCommandValidator : AbstractValidator<DeleteHoleCommand>
{
    public DeleteHoleCommandValidator()
    {
        RuleFor(command => command.Id).NotEqual(Guid.Empty);
    }
}
