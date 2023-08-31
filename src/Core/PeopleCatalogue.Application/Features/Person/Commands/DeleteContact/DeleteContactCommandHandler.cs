using AutoMapper;
using MediatR;
using ContactsBook.Application.Contracts.Persistence;
using ContactsBook.Application.Exceptions;

namespace ContactsBook.Application.Features.Person.Commands.DeleteContact
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _personRepository;

        public DeleteContactCommandHandler(
            IMapper mapper,
            IContactRepository personRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }

        public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetAsync(request.Id) ??
                throw new NotFoundException(nameof(Contact), request.Id);

            await _personRepository.DeleteAsync(person);

            return Unit.Value;
        }
    }
}
