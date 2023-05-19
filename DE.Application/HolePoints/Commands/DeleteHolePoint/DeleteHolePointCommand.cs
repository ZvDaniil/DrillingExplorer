using DE.Application.Interfaces;

namespace DE.Application.HolePoints.Commands.DeleteHolePoint;

public record DeleteHolePointCommand(Guid HoleId) : ICommand;