using AutoMapper;
using ContactsBook.Application.Features.Contact.Queries.GetAllContacts;
using ContactsBook.Domain;

namespace ContactsBook.Application.MappingProfiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressDetailsDto>();
            CreateMap<Address, AddressDto>();
        }
    }
}
