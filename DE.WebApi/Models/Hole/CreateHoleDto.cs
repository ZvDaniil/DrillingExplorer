using AutoMapper;
using DE.Application.Common.Mappings;
using DE.Application.Holes.Commands.CreateHole;

namespace DE.WebApi.Models.Hole;

public class CreateHoleDto : IMapWith<CreateHoleCommand>
{
    public string Name { get; set; } = string.Empty;
    public double Depth { get; set; }
    public Guid DrillBlockId { get; set; }

    public void Mapping(Profile profile) =>
        profile.CreateMap<CreateHoleDto, CreateHoleCommand>()
        .ForMember(command => command.Name, opt => opt.MapFrom(dto => dto.Name))
        .ForMember(command => command.Depth, opt => opt.MapFrom(dto => dto.Depth))
        .ForMember(command => command.DrillBlockId, opt => opt.MapFrom(dto => dto.DrillBlockId));
}