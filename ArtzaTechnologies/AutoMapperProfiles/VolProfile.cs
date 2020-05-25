using ArtzaTechnologies.AutoMapperProfiles.Resolver;
using ArtzaTechnologies.DAL.Domains;
using ArtzaTechnologies.Dto;
using AutoMapper;

namespace ArtzaTechnologies.AutoMapperProfiles
{
    public class VolProfile:Profile
    {
        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public VolProfile()
        {
            //CreateMap<VolDto, Vol>();
            CreateMap<Vol, VolDto>()
                .ForMember(dest => dest.Depart, opt => opt.MapFrom(src => src.AeroportDepart.Nom))
                .ForMember(dest => dest.Arrivee, opt => opt.MapFrom(src => src.AeroportArrivee.Nom))
                .ForMember(dest => dest.Avion, opt => opt.MapFrom(src => src.Avion.Libelle))
                .ForMember(dest => dest.Distance, opt => opt.MapFrom<DistanceResolver>())
                .ForMember(dest => dest.KeroseneNecessaire, opt => opt.MapFrom<ConsommationResolver>())
                .ForMember(dest => dest.DureeVol, opt => opt.MapFrom<DureeVolResolver>()).ReverseMap();
        }
    }
}
