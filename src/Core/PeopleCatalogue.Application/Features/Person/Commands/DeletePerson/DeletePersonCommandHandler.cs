using AutoMapper;
using MediatR;
using PeopleCatalogue.Application.Contracts.Persistence;

namespace PeopleCatalogue.Application.Features.Person.Commands.DeletePerson
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;

        public DeletePersonCommandHandler(
            IMapper mapper,
            IPersonRepository personRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }

        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetAsync(request.Id);

            await _personRepository.DeleteAsync(person);

            return Unit.Value;
        }
    }
}
