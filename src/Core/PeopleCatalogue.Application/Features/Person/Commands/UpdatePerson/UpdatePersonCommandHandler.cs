using AutoMapper;
using MediatR;
using PeopleCatalogue.Application.Contracts.Persistence;

namespace PeopleCatalogue.Application.Features.Person.Commands.UpdatePerson
{
    internal class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;

        public UpdatePersonCommandHandler(
            IMapper mapper,
            IPersonRepository personRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }

        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<Domain.Person>(request);

            await _personRepository.UpdateAsync(person);

            return Unit.Value;
        }
    }
}
