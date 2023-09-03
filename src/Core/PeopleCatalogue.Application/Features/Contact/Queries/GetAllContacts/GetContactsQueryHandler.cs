using AutoMapper;
using MediatR;
using ContactsBook.Application.Contracts.Persistence;

namespace ContactsBook.Application.Features.Contact.Queries.GetAllContacts
{
    public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, List<ContactDto>>
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        public GetContactsQueryHandler(
            IMapper mapper,
            IContactRepository contactRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        public async Task<List<ContactDto>> Handle(
            GetContactsQuery request,
            CancellationToken cancellationToken)
        {
            var people = await _contactRepository.GetAsync(nameof(Domain.Contact.Address));
            var data = _mapper.Map<List<ContactDto>>(people);

            return data;
        }
    }
}
