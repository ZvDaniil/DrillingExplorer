using AutoMapper;
using DE.Application.Common.Mappings;
using DE.Domain.Models;

namespace DE.Application.HolePoints.ViewModels;

public class HolePointDto : IMapWith<HolePoint>
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public void Mapping(Profile profile) =>
        profile.CreateMap<HolePoint, HolePointDto>()
        .ForMember(dto => dto.X, opt => opt.MapFrom(point => point.X))
        .ForMember(dto => dto.Y, opt => opt.MapFrom(point => point.Y))
        .ForMember(dto => dto.Z, opt => opt.MapFrom(point => point.Z));
}
