using AutoMapper;
using MediatR;
using ContactsBook.Application.Contracts.Persistence;

namespace ContactsBook.Application.Features.Contact.Commands.UpdateContact
{
    internal class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _personRepository;

        public UpdateContactCommandHandler(
            IMapper mapper,
            IContactRepository personRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }

        public async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<Domain.Contact>(request);

            await _personRepository.UpdateAsync(person);

            return Unit.Value;
        }
    }
}
