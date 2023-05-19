using FluentValidation;

namespace DE.Application.DrillBlockPoints.Commands.UpdatePoint;

public sealed class UpdateDrillBlockPointCommandValidator : AbstractValidator<UpdateDrillBlockPointCommand>
{
    public UpdateDrillBlockPointCommandValidator()
    {
        RuleFor(command => command.DrillBlockId).NotEqual(Guid.Empty);
        RuleFor(command => command.PointId).NotEqual(Guid.Empty);
    }
}