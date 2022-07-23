using AutoMapper;
using SampleWebAPI.Domain;
using SampleWebAPI.DTO;

namespace SampleWebAPI.Profiles
{
    public class SamuraiProfile : Profile
    {
        public SamuraiProfile()
        {
            CreateMap<ElementSword, ElementSwordReadDTO>();


            //semua
            CreateMap<Samurai, SamuraiWithAll>();
            CreateMap<Sword, SwordWithAllDTO>();

            CreateMap<SwordWithTypeCreateDTO, Sword>();
           
            CreateMap<TypeEl, TypeCreateDTO>();


            //CreateMap<SamuraiWithQuotesDTO, Samurai>();
            CreateMap<Samurai, SamuraiWithQuotesDTO>();
            CreateMap<SamuraiWithQuotesDTO, Samurai>();


            CreateMap<SamuraiSwordCreateDTO, Samurai >();
            CreateMap<SamuraiSwordCreateDTO, Sword>();

            CreateMap<Sword, SwordTypeDTO>();
            CreateMap<SwordTypeDTO, Sword>();

            

            CreateMap<SamuraiSwordCreateDTO, Sword>();
            CreateMap<SamuraiSwordReadDTO, Sword>();
            CreateMap<Sword, SamuraiSwordReadDTO>();
            CreateMap<SamuraiSwordCreateDTO, Samurai>();
            CreateMap<SamuraiSwordReadDTO, Samurai>();
            CreateMap<Samurai, SamuraiSwordReadDTO>();
            CreateMap<Sword, SamuraiSwordReadDTO>();

            CreateMap<SwordAddToExistingElementDTO, Sword>();
            CreateMap<SwordAddToExistingElementDTO, Element>();

            CreateMap<SwordElementReadDTO, Sword>();
            CreateMap<Sword, SwordElementReadDTO>();


            CreateMap<SwordTypeCreateDTO, Sword>();
            CreateMap<SwordTypeCreateDTO, TypeEl>();

            CreateMap<TypeEl, TypeCreateNoIdDTO>();
            CreateMap<TypeCreateNoIdDTO, TypeEl>();
            CreateMap<TypeCreateDTO, TypeEl>();

            CreateMap<SwordTypeReadDTO, Sword>();
            CreateMap<SwordTypeReadDTO, TypeEl>();
            CreateMap<Sword, SwordTypeReadDTO>();
            CreateMap<TypeEl, SwordTypeReadDTO>();

            CreateMap<SwordCreateDTO, SamuraiSwordCreateDTO>();
            CreateMap<SamuraiSwordCreateDTO, SwordCreateDTO>();

            CreateMap<Samurai, SamuraiReadDTO>();
            CreateMap<SamuraiReadDTO, Samurai>();
            CreateMap<SamuraiCreateDTO, Samurai>();

            CreateMap<QuoteDTO, Quote>();
            CreateMap<Quote,QuoteDTO>();

            CreateMap<SwordCreateNoSamuraiInputDTO, Sword>();
            CreateMap<SwordCreateDTO, Sword>();
            CreateMap<Sword, SwordReadDTO>();
            CreateMap<SwordReadDTO, Sword>();

            CreateMap<Element, ElementReadDTO>();
            CreateMap<ElementReadDTO, Element>();
            CreateMap<ElementCreateDTO, Element>();

            CreateMap<TypeEl, TypeReadDTO>();
            CreateMap<TypeReadDTO, TypeEl>();
            CreateMap<TypeCreateDTO, TypeEl>();

            CreateMap<ElementSword, ElementSwordDTO>();
            CreateMap<ElementSwordDTO, ElementSword>();
        }
    }
}
