using AutoMapper;
using MediatR;
using ContactsBook.Application.Contracts.Persistence;

namespace ContactsBook.Application.Features.Contact.Queries.GetAllContacts
{
    public class GetAddressDetailsQueryHandler : IRequestHandler<GetAddressDetailsQuery, AddressDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;

        public GetAddressDetailsQueryHandler(
            IMapper mapper,
            IAddressRepository addressRepository)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        public async Task<AddressDetailsDto> Handle(
            GetAddressDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var address = await _addressRepository.GetAsync(request.Id);
            var addressDto = _mapper.Map<AddressDetailsDto>(address);

            return addressDto;
        }
    }
}
