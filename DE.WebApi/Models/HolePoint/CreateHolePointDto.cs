using AutoMapper;
using DE.Application.Common.Mappings;
using DE.Application.HolePoints.Commands.CreateHolePoint;

namespace DE.WebApi.Models.HolePoint;

public class CreateHolePointDto : IMapWith<CreateHolePointCommand>
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public void Mapping(Profile profile) =>
        profile.CreateMap<CreateHolePointDto, CreateHolePointCommand>()
        .ForMember(command => command.X, opt => opt.MapFrom(dto => dto.X))
        .ForMember(command => command.Y, opt => opt.MapFrom(dto => dto.Y))
        .ForMember(command => command.Z, opt => opt.MapFrom(dto => dto.Z))

        .ForMember(command => command.HoleId,
            opt => opt.MapFrom((dto, command, destMember, context) => context.Items["HoleId"]));
}