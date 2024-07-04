using AutoMapper;
using Pilotos.Dtos;
using Pilotos.Models;

namespace Pilotos
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<Piloto, PilotoDto>()
                .ForMember(dest => dest.Nacionalidad, source => source.MapFrom(x => x.Nacionalidad.Descripcion));
            CreateMap<PostPilotoDto, Piloto>()
                .ForMember(dest => dest.NacionalidadId, source => source.MapFrom(x => x.NacionalidadId))
                .ForMember(dest => dest.Id, source => source.MapFrom(x => new int()));
        }
    }
}
