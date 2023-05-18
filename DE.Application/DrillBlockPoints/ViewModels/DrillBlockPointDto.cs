using AutoMapper;
using DE.Domain.Models;
using DE.Application.Common.Mappings;

namespace DE.Application.DrillBlockPoints.ViewModels;

public class DrillBlockPointDto : IMapWith<DrillBlockPoint>
{
    public Guid Id { get; set; }
    public int Sequence { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public void Mapping(Profile profile) =>
        profile.CreateMap<DrillBlockPoint, DrillBlockPointDto>()
        .ForMember(dto => dto.Id, opt => opt.MapFrom(point => point.Id))
        .ForMember(dto => dto.Sequence, opt => opt.MapFrom(point => point.Sequence))
        .ForMember(dto => dto.X, opt => opt.MapFrom(point => point.X))
        .ForMember(dto => dto.Y, opt => opt.MapFrom(point => point.Y))
        .ForMember(dto => dto.Z, opt => opt.MapFrom(point => point.Z));
}