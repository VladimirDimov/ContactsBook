using MediatR;

namespace ContactsBook.Application.Features.Contact.Queries.GetContactDetails
{
    public record GetContactDetailsQuery(int Id) : IRequest<ContactDetailsDto>;
}
