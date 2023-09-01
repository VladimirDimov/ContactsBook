namespace ContactsBook.Domain.Events
{
    public class AddressAddedEvent : BaseDomainEvent
    {
        public int GuestbookId { get; }
        public Address Entry { get; }

        public AddressAddedEvent(int guestbookId, Address entry)
        {
            GuestbookId = guestbookId;
            Entry = entry;
        }
    }
}
