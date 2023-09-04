namespace ContactsBook.Domain.Events
{
    public class AddressAddedEvent : BaseDomainEvent
    {
        public Address Entry { get; }

        public AddressAddedEvent(Address entry)
        {
            Entry = entry;
        }
    }
}
