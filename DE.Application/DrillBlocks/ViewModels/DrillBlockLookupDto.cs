using AutoMapper;
using DE.Application.Common.Mappings;
using DE.Domain.Models;

namespace DE.Application.DrillBlocks.ViewModels;

public class DrillBlockLookupDto : IMapWith<DrillBlock>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public void Mapping(Profile profile) =>
        profile.CreateMap<DrillBlock, DrillBlockLookupDto>()
        .ForMember(dto => dto.Id, opt => opt.MapFrom(drillBlock => drillBlock.Id))
        .ForMember(dto => dto.Name, opt => opt.MapFrom(drillBlock => drillBlock.Name));
}