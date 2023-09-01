namespace ContactsBook.Domain.Events
{
    public class AddressDeletedEvent : BaseDomainEvent
    {
        public Address Entry { get; }

        public AddressDeletedEvent(Address entry)
        {
            Entry = entry;
        }
    }
}
