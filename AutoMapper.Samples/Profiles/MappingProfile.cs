using AutoMapper.Samples.Models;
using AutoMapper.Samples.DTO;
namespace AutoMapper.Samples.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookModel, BookFullDTO>()
                .ForMember(m => m.FirstName, opt => opt.MapFrom(s => s.Author.FirstName))
                .ForMember(m => m.LastName, opt => opt.MapFrom(s => s.Author.LastName))
                .ReverseMap();
            CreateMap<AuthorModel, AuthorDTO>();
        }

    }
}
