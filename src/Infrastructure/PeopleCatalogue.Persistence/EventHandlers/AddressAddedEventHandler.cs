using ContactsBook.Application.Contracts.Persistence;
using ContactsBook.Domain.Events;
using ContactsBook.Domain.Interfaces;

namespace ContactsBook.Persistence.EventHandlers
{
    internal class AddressAddedEventHandler : IHandle<AddressAddedEvent>
    {
        private readonly IAddressRepository _addressRepository;

        public AddressAddedEventHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public void Handle(AddressAddedEvent domainEvent)
        {
            _addressRepository.CreateAsync(domainEvent.Entry).GetAwaiter().GetResult();
        }
    }
}
