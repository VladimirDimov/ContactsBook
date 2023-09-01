using AutoMapper;
using ContactsBook.Application.Features.Address.Queries.GetAddressDetails;
using ContactsBook.Application.Features.Address.Queries.GetContactAddresses;
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
