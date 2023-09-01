using MediatR;

namespace ContactsBook.Application.Features.Contact.Queries.GetAllContacts
{
    public record GetAddressDetailsQuery(int Id) : IRequest<AddressDetailsDto>;
}
