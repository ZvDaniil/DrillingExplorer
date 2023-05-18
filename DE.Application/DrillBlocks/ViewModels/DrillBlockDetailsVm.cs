using AutoMapper;
using DE.Domain.Models;
using DE.Application.Common.Mappings;
using DE.Application.Holes.ViewModels;
using DE.Application.DrillBlockPoints.ViewModels;

namespace DE.Application.DrillBlocks.ViewModels;

public class DrillBlockDetailsVm : IMapWith<DrillBlock>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime? UpdateDate { get; set; }
    public IEnumerable<HoleLookupDto>? Holes { get; set; }
    public IEnumerable<DrillBlockPointDto>? DrillBlockPoints { get; set; }

    public void Mapping(Profile profile) =>
        profile.CreateMap<DrillBlock, DrillBlockDetailsVm>()
        .ForMember(vm => vm.Id, opt => opt.MapFrom(drillBlock => drillBlock.Id))
        .ForMember(vm => vm.Name, opt => opt.MapFrom(drillBlock => drillBlock.Name))
        .ForMember(vm => vm.UpdateDate, opt => opt.MapFrom(drillBlock => drillBlock.UpdateDate))

        .ForMember(vm => vm.Holes,
            opt => opt.MapFrom(drillBlock => drillBlock.Holes == null
                    ? new List<HoleLookupDto>()
                    : drillBlock.Holes.Select(h => new HoleLookupDto
                    {
                        Id = h.Id,
                        Name = h.Name,
                    })))

        .ForMember(vm => vm.DrillBlockPoints,
            opt => opt.MapFrom(drillBlock => drillBlock.DrillBlockPoints == null
                ? new List<DrillBlockPointDto>()
                : drillBlock.DrillBlockPoints.Select(p => new DrillBlockPointDto
                {
                    Id = p.Id,
                    Sequence = p.Sequence,
                    X = p.X,
                    Y = p.Y
                    Z = p.Z
                })));
}