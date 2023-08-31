using AutoMapper;
using MediatR;
using PeopleCatalogue.Application.Contracts.Persistence;

namespace PeopleCatalogue.Application.Features.Person.Queries.GetAllPeople
{
    public class GetPeopleQueryHandler : IRequestHandler<GetPeopleQuery, List<PersonDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;

        public GetPeopleQueryHandler(
            IMapper mapper,
            IPersonRepository personRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }

        public async Task<List<PersonDto>> Handle(
            GetPeopleQuery request,
            CancellationToken cancellationToken)
        {
            var people = await _personRepository.GetAsync();
            var data = _mapper.Map<List<PersonDto>>(people);

            return data;
        }
    }
}
