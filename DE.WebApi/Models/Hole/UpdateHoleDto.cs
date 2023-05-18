using AutoMapper;
using DE.Application.Common.Mappings;
using DE.Application.Holes.Commands.UpdateHole;

namespace DE.WebApi.Models.Hole;

public class UpdateHoleDto : IMapWith<UpdateHoleCommand>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Depth { get; set; }

    public void Mapping(Profile profile) =>
        profile.CreateMap<UpdateHoleDto, UpdateHoleCommand>()
        .ForMember(command => command.Id, opt => opt.MapFrom(dto => dto.Id))
        .ForMember(command => command.Name, opt => opt.MapFrom(dto => dto.Name))
        .ForMember(command => command.Depth, opt => opt.MapFrom(dto => dto.Depth));
}