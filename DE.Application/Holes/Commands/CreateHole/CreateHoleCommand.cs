using DE.Application.Interfaces;

namespace DE.Application.Holes.Commands.CreateHole;

public record CreateHoleCommand(string Name, double Depth, Guid DrillBlockId) : ICommand<Guid>;