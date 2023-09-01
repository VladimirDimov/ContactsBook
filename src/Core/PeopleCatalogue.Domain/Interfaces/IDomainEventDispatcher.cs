using ContactsBook.Domain.Events;

namespace ContactsBook.Domain.Interfaces
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(BaseDomainEvent domainEvent);
    }
}
