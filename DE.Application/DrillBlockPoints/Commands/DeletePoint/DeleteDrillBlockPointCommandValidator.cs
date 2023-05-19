using FluentValidation;

namespace DE.Application.DrillBlockPoints.Commands.DeletePoint;

public sealed class DeleteDrillBlockPointCommandValidator : AbstractValidator<DeleteDrillBlockPointCommand>
{
    public DeleteDrillBlockPointCommandValidator()
    {
        RuleFor(command => command.DrillBlockId).NotEqual(Guid.Empty);
        RuleFor(command => command.PointId).NotEqual(Guid.Empty);
    }
}
