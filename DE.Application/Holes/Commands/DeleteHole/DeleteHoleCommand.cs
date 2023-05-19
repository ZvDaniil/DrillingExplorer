using DE.Application.Interfaces;

namespace DE.Application.Holes.Commands.DeleteHole;

public record DeleteHoleCommand(Guid Id) : ICommand;