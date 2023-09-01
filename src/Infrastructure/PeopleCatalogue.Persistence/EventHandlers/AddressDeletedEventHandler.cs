using ContactsBook.Application.Contracts.Persistence;
using ContactsBook.Domain.Events;
using ContactsBook.Domain.Interfaces;

namespace ContactsBook.Persistence.EventHandlers
{
    internal class AddressDeletedEventHandler : IHandle<AddressDeletedEvent>
    {
        private readonly IAddressRepository _addressRepository;

        public AddressDeletedEventHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public void Handle(AddressDeletedEvent domainEvent)
        {
            _addressRepository.DeleteAsync(domainEvent.Entry).GetAwaiter().GetResult();
        }
    }
}
