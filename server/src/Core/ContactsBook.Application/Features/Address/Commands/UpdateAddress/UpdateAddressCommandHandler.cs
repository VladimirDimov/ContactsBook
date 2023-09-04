using AutoMapper;
using MediatR;
using ContactsBook.Application.Contracts.Persistence;
using ContactsBook.Application.Exceptions;
using ContactsBook.Application.Features.Address.Commands.CreateAddress;

namespace ContactsBook.Application.Features.Address.Commands.UpdateAddress
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;
        private readonly IAddressRepository _addressRepository;

        public UpdateAddressCommandHandler(
            IMapper mapper,
            IContactRepository contactRepository,
            IAddressRepository addressRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
            _addressRepository = addressRepository;
        }

        public async Task<int> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAddressCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid address data", validationResult);

            var address = await _addressRepository.GetAsync(request.Id)
                ?? throw new NotFoundException(nameof(Domain.Address), request.Id);

            var contact = await _contactRepository.GetAsync(request.ContactId)
                ?? throw new NotFoundException(nameof(Contact), request.ContactId);

            contact.AddAddress(address);

            var updatedContact = await _contactRepository.UpdateAsync(contact);

            return updatedContact.Id;
        }
    }
}
