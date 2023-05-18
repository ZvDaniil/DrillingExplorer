using AutoMapper;
using DE.Application.Common.Mappings;
using DE.Application.DrillBlocks.Commands.UpdateDrillBlock;

namespace DE.WebApi.Models.DrillBlock;

public class UpdateDrillBlockDto : IMapWith<UpdateDrillBlockCommand>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public void Mapping(Profile profile) =>
        profile.CreateMap<UpdateDrillBlockDto, UpdateDrillBlockCommand>()
        .ForMember(command => command.Id, opt => opt.MapFrom(dto => dto.Id))
        .ForMember(command => command.Name, opt => opt.MapFrom(dto => dto.Name));
}
