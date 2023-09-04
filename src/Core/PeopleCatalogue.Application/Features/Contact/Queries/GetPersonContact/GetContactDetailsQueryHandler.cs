using AutoMapper;
using AutoMapper.Configuration.Annotations;
using MediatR;
using ContactsBook.Application.Contracts.Persistence;

namespace ContactsBook.Application.Features.Contact.Queries.GetContactDetails
{
    public class GetContactDetailsQueryHandler : IRequestHandler<GetContactDetailsQuery, ContactDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        public GetContactDetailsQueryHandler(
            IMapper mapper,
            IContactRepository contactRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        public async Task<ContactDetailsDto> Handle(GetContactDetailsQuery request, CancellationToken cancellationToken)
        {
            var contact = await _contactRepository.GetAsync(request.Id);
            var data = _mapper.Map<ContactDetailsDto>(contact);

            return data;
        }
    }
}
