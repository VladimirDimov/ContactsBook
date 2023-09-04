using AutoMapper;
using ContactsBook.Application.Features.Contact.Commands.CreateContact;
using ContactsBook.Application.Features.Contact.Commands.UpdateContact;
using ContactsBook.Application.Features.Contact.Queries.GetAllContacts;
using ContactsBook.Application.Features.Contact.Queries.GetContactDetails;
using ContactsBook.Domain;

namespace ContactsBook.Application.MappingProfiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<ContactDto, Contact>().ReverseMap();
            CreateMap<ContactDetailsDto, Contact>().ReverseMap();
            CreateMap<CreateContactCommand, Contact>();
            CreateMap<UpdateContactCommand, Contact>();
        }
    }
}
