using FluentValidation;

namespace DE.Application.DrillBlockPoints.Commands.CreatePoint;

public sealed class CreateDrillBlockPointCommandValidator : AbstractValidator<CreateDrillBlockPointCommand>
{
    public CreateDrillBlockPointCommandValidator()
    {
        RuleFor(command => command.DrillBlockId).NotEqual(Guid.Empty);
    }
}
