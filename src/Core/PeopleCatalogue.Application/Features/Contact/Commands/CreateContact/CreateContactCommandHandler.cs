using AutoMapper;
using MediatR;
using ContactsBook.Application.Contracts.Persistence;
using ContactsBook.Application.Exceptions;

namespace ContactsBook.Application.Features.Contact.Commands.CreateContact
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _personRepository;

        public CreateContactCommandHandler(
            IMapper mapper,
            IContactRepository personRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }

        public async Task<int> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateContactCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid person data", validationResult);

            var person = _mapper.Map<Domain.Contact>(request);

            var createdPerson = await _personRepository.CreateAsync(person);

            return createdPerson.Id;
        }
    }
}
