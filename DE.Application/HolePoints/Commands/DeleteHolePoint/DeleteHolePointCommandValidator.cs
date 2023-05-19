using FluentValidation;

namespace DE.Application.HolePoints.Commands.DeleteHolePoint;

public sealed class DeleteHolePointCommandValidator : AbstractValidator<DeleteHolePointCommand>
{
    public DeleteHolePointCommandValidator()
    {
        RuleFor(command => command.HoleId).NotEqual(Guid.Empty);
    }
}
