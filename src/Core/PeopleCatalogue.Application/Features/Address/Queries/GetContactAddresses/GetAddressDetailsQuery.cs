using MediatR;

namespace ContactsBook.Application.Features.Address.Queries.GetContactAddresses
{
    public record GetAddressesbyContactQuery(int ContactId) : IRequest<List<AddressDto>>;
}
