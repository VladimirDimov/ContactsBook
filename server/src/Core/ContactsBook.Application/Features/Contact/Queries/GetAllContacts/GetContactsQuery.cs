using MediatR;

namespace ContactsBook.Application.Features.Contact.Queries.GetAllContacts
{
    public record GetContactsQuery : IRequest<List<ContactDto>>;
}
