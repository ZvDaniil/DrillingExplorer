using AutoMapper;
using DE.Domain.Models;
using DE.Application.Common.Mappings;
using DE.Application.DrillBlocks.ViewModels;

namespace DE.Application.DrillBlockPoints.ViewModels;

public class DrillBlockPointDetailsVm : IMapWith<DrillBlockPoint>
{
    public Guid Id { get; set; }

    public int Sequence { get; set; }

    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public DrillBlockLookupDto DrillBlock { get; set; } = default!;

    public void Mapping(Profile profile) =>
        profile.CreateMap<DrillBlockPoint, DrillBlockPointDetailsVm>()
        .ForMember(vm => vm.Id, opt => opt.MapFrom(point => point.Id))
        .ForMember(vm => vm.Sequence, opt => opt.MapFrom(point => point.Sequence))
        .ForMember(vm => vm.X, opt => opt.MapFrom(point => point.X))
        .ForMember(vm => vm.Y, opt => opt.MapFrom(point => point.Y))
        .ForMember(vm => vm.Z, opt => opt.MapFrom(point => point.Z))
        .ForMember(vm => vm.Z, opt => opt.MapFrom(point => point.Z))

        .ForMember(vm => vm.DrillBlock, opt => opt.MapFrom(point =>
            new DrillBlockLookupDto
            {
                Id = point.DrillBlock.Id,
                Name = point.DrillBlock.Name
            }));
}