using AutoMapper;
using MediatR;
using ContactsBook.Application.Contracts.Persistence;
using ContactsBook.Application.Exceptions;

namespace ContactsBook.Application.Features.Person.Commands.DeleteContact
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;
        private readonly IAddressRepository _addressRepository;

        public DeleteContactCommandHandler(
            IMapper mapper,
            IContactRepository contactRepository,
            IAddressRepository addressRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
            _addressRepository = addressRepository;
        }

        public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var address = await _addressRepository.GetAsync(request.Id)
                ?? throw new NotFoundException(nameof(Domain.Address), request.Id);

            var contact = await _contactRepository.GetAsync(address.ContactId);

            contact.RemoveAddress(address);

            await _contactRepository.UpdateAsync(contact);

            return Unit.Value;
        }
    }
}
