using MediatR;

namespace ContactsBook.Application.Features.Contact.Queries.GetAllContacts
{
    public record GetAddressesbyContactQuery(int ContactId) : IRequest<List<AddressDto>>;
}
