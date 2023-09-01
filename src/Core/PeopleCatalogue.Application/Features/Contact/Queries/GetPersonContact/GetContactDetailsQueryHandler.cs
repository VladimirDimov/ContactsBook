using AutoMapper;
using AutoMapper.Configuration.Annotations;
using MediatR;
using ContactsBook.Application.Contracts.Persistence;

namespace ContactsBook.Application.Features.Contact.Queries.GetContactDetails
{
    public class GetContactDetailsQueryHandler : IRequestHandler<GetContactDetailsQuery, ContactDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _personRepository;

        public GetContactDetailsQueryHandler(
            IMapper mapper,
            IContactRepository personRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }

        public async Task<ContactDetailsDto> Handle(GetContactDetailsQuery request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetAsync(request.Id);
            var data = _mapper.Map<ContactDetailsDto>(person);

            return data;
        }
    }
}
