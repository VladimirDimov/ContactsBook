using AutoMapper;
using MediatR;
using ContactsBook.Application.Contracts.Persistence;

namespace ContactsBook.Application.Features.Contact.Queries.GetAllContacts
{
    public class GetAddressByContactQueryHandler : IRequestHandler<GetAddressesbyContactQuery, List<AddressDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;

        public GetAddressByContactQueryHandler(
            IMapper mapper,
            IAddressRepository addressRepository)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        public async Task<List<AddressDto>> Handle(
            GetAddressesbyContactQuery request,
            CancellationToken cancellationToken)
        {
            var addresses = await _addressRepository.GetByContactId(request.ContactId);
            var addressDto = _mapper.Map<List<AddressDto>>(addresses);

            return addressDto;
        }
    }
}
