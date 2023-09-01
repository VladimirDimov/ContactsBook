using ContactsBook.Application.Features.Address.Queries.GetAddressDetails;
using MediatR;

namespace ContactsBook.Application.Features.Address.Queries.GetAddressDetails
{
    public record GetAddressDetailsQuery(int Id) : IRequest<AddressDetailsDto>;
}
