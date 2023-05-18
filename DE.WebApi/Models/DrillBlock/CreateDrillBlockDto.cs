using AutoMapper;
using DE.Application.Common.Mappings;
using DE.Application.DrillBlocks.Commands.CreateDrillBlock;

namespace DE.WebApi.Models.DrillBlock;

public class CreateDrillBlockDto : IMapWith<CreateDrillBlockCommand>
{
    public string Name { get; set; } = string.Empty;

    public void Mapping(Profile profile) =>
        profile.CreateMap<CreateDrillBlockDto, CreateDrillBlockCommand>()
        .ForMember(command => command.Name, opt => opt.MapFrom(dto => dto.Name));
}