namespace ContactsBook.Domain.Events
{
    public class AddressUpdatedEvent : BaseDomainEvent
    {
        public Address Entry { get; }

        public AddressUpdatedEvent(Address entry)
        {
            Entry = entry;
        }
    }
}
