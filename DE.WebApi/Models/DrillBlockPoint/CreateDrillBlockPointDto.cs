using AutoMapper;
using DE.Application.Common.Mappings;
using DE.Application.DrillBlockPoints.Commands.CreatePoint;

namespace DE.WebApi.Models.DrillBlockPoint;

public record CreateDrillBlockPointDto : IMapWith<CreateDrillBlockPointCommand>
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public void Mapping(Profile profile) =>
            profile.CreateMap<CreateDrillBlockPointDto, CreateDrillBlockPointCommand>()
            .ForMember(command => command.X, opt => opt.MapFrom(dto => dto.X))
            .ForMember(command => command.Y, opt => opt.MapFrom(dto => dto.Y))
            .ForMember(command => command.Z, opt => opt.MapFrom(dto => dto.Z))

            .ForMember(command => command.DrillBlockId,
                opt => opt.MapFrom((dto, command, destMember, context)
                    => context.Items["DrillBlockId"]));
}
