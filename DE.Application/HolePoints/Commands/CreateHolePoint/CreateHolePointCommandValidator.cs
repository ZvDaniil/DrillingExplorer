using FluentValidation;

namespace DE.Application.HolePoints.Commands.CreateHolePoint;

public sealed class CreateHolePointCommandValidator : AbstractValidator<CreateHolePointCommand>
{
    public CreateHolePointCommandValidator()
    {
        RuleFor(command => command.HoleId).NotEqual(Guid.Empty);
    }
}