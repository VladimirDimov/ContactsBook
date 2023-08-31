using AutoMapper;
using AutoMapper.Configuration.Annotations;
using MediatR;
using PeopleCatalogue.Application.Contracts.Persistence;

namespace PeopleCatalogue.Application.Features.Person.Queries.GetPersonDetails
{
    public class GetPersonDetailsQueryHandler : IRequestHandler<GetPersonDetailsQuery, PersonDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;

        public GetPersonDetailsQueryHandler(
            IMapper mapper,
            IPersonRepository personRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }

        public async Task<PersonDetailsDto> Handle(GetPersonDetailsQuery request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetAsync(request.Id);
            var data = _mapper.Map<PersonDetailsDto>(person);

            return data;
        }
    }
}
