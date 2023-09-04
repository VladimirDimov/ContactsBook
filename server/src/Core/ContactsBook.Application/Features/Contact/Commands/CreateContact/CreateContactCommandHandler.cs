using AutoMapper;
using MediatR;
using ContactsBook.Application.Contracts.Persistence;
using ContactsBook.Application.Exceptions;

namespace ContactsBook.Application.Features.Contact.Commands.CreateContact
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, int>
    {
        private readonly IContactRepository _contactRepository;

        public CreateContactCommandHandler(
            IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<int> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            //var validator = new CreateContactCommandValidator();
            //var validationResult = await validator.ValidateAsync(request, cancellationToken);

            //if (!validationResult.IsValid)
            //    throw new BadRequestException("Invalid contact data", validationResult);

            var contact = new Domain.Contact(
                request.FirstName,
                request.LastName,
                request.DateOfBirth,
                request.PhoneNumber,
                request.Iban);

            var createdContact = await _contactRepository.CreateAsync(contact);

            return createdContact.Id;
        }
    }
}
