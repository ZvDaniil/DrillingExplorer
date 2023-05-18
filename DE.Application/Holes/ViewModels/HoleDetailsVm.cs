using AutoMapper;
using DE.Application.Common.Mappings;
using DE.Application.DrillBlocks.ViewModels;
using DE.Application.HolePoints.ViewModels;
using DE.Domain.Models;

namespace DE.Application.Holes.ViewModels;

public class HoleDetailsVm : IMapWith<Hole>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Depth { get; set; }
    public DrillBlockLookupDto DrillBlock { get; set; } = null!;
    public HolePointDto? HolePoint { get; set; }

    public void Mapping(Profile profile) =>
        profile.CreateMap<Hole, HoleDetailsVm>()
        .ForMember(vm => vm.Id, opt => opt.MapFrom(hole => hole.Id))
        .ForMember(vm => vm.Name, opt => opt.MapFrom(hole => hole.Name))
        .ForMember(vm => vm.Depth, opt => opt.MapFrom(hole => hole.Depth))

        .ForMember(vm => vm.DrillBlock, opt => opt.MapFrom(hole =>
            new DrillBlockLookupDto
            {
                Id = hole.DrillBlockId,
                Name = hole.DrillBlock.Name
            }))

        .ForMember(vm => vm.Id, opt => opt.MapFrom(hole =>
            hole.HolePoint != null
                ? new HolePointDto
                {
                    X = hole.HolePoint.X,
                    Y = hole.HolePoint.Y,
                    Z = hole.HolePoint.Z
                }
                : default));
}