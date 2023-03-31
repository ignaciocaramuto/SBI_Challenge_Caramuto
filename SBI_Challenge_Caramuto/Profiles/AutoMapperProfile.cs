using AutoMapper;
using SBI_Challenge_Caramuto.DTO;
using SBI_Challenge_Caramuto.Model;

namespace SBI_Challenge_Caramuto.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ServerPost, Salida>()
                .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.title));
        }
    }
}
