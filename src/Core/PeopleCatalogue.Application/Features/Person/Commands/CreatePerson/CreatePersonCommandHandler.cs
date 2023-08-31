using AutoMapper;
using MediatR;
using PeopleCatalogue.Application.Contracts.Persistence;

namespace PeopleCatalogue.Application.Features.Person.Commands.CreatePerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;

        public CreatePersonCommandHandler(
            IMapper mapper,
            IPersonRepository personRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }

        public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<Domain.Person>(request);

            var createdPerson = await _personRepository.CreateAsync(person);

            return createdPerson.Id;
        }
    }
}
