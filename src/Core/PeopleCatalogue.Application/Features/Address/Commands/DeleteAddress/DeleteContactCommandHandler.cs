using AutoMapper;
using MediatR;
using ContactsBook.Application.Contracts.Persistence;
using ContactsBook.Application.Exceptions;
using ContactsBook.Application.Features.Address.Commands.DeleteAddress;

namespace ContactsBook.Application.Features.Person.Commands.DeleteContact
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _personRepository;
        private readonly IAddressRepository _addressRepository;

        public DeleteAddressCommandHandler(
            IMapper mapper,
            IContactRepository personRepository,
            IAddressRepository addressRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
            _addressRepository = addressRepository;
        }

        public async Task<Unit> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _addressRepository.GetAsync(request.Id)
                ?? throw new NotFoundException(nameof(Domain.Address), request.Id);

            var contact = await _personRepository.GetAsync(request.Id) ??
                throw new NotFoundException(nameof(Contact), request.Id);

            contact.RemoveAddress(address);

            return Unit.Value;
        }
    }
}
