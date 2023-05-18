using AutoMapper;
using DE.Domain.Models;
using DE.Application.Common.Mappings;

namespace DE.Application.Holes.ViewModels;

public class HoleLookupDto : IMapWith<Hole>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public void Mapping(Profile profile) =>
        profile.CreateMap<Hole, HoleLookupDto>()
        .ForMember(vm => vm.Id, opt => opt.MapFrom(hole => hole.Id))
        .ForMember(vm => vm.Name, opt => opt.MapFrom(hole => hole.Name));
}