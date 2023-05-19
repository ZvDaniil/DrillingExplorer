using FluentValidation;

namespace DE.Application.HolePoints.Commands.UpdateHolePoint;

public sealed class UpdateHolePointCommandValidator : AbstractValidator<UpdateHolePointCommand>
{
    public UpdateHolePointCommandValidator()
    {
        RuleFor(command => command.HoleId).NotEqual(Guid.Empty);
    }
}
