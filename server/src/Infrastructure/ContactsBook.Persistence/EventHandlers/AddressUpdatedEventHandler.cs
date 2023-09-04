using ContactsBook.Application.Contracts.Persistence;
using ContactsBook.Domain.Events;
using ContactsBook.Domain.Interfaces;

namespace ContactsBook.Persistence.EventHandlers
{
    internal class AddressUpdatedEventHandler : IHandle<AddressUpdatedEvent>
    {
        private readonly IAddressRepository _addressRepository;

        public AddressUpdatedEventHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public void Handle(AddressUpdatedEvent domainEvent)
        {
            _addressRepository.UpdateAsync(domainEvent.Entry).GetAwaiter().GetResult();
        }
    }
}
