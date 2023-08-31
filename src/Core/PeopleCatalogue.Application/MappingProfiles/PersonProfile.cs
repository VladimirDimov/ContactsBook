using AutoMapper;
using PeopleCatalogue.Application.Features.Person.Queries.GetAllPeople;
using PeopleCatalogue.Domain;

namespace PeopleCatalogue.Application.MappingProfiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonDto, Person>().ReverseMap();
            CreateMap<PersonDetailsDto, Person>().ReverseMap();
        }
    }
}
