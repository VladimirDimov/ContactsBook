using AutoMapper;
using ContactsBook.Application.Contracts.Persistence;
using ContactsBook.Application.Features.Contact.Commands.DeleteContact;
using MediatR;

namespace ContactsBook.Application.Features.Contact.Commands.DeleteContact
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
            var contact = await _contactRepository.GetAsync(request.Id);

            await _contactRepository.DeleteAsync(contact);

            return Unit.Value;
        }
    }
}
