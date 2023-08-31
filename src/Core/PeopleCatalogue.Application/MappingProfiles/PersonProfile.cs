using AutoMapper;
using PeopleCatalogue.Domain;

namespace PeopleCatalogue.Application.MappingProfiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonDto, Person>().ReverseMap();
        }
    }
}
