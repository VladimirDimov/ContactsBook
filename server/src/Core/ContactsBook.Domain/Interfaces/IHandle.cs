using ContactsBook.Domain.Events;

namespace ContactsBook.Domain.Interfaces
{
    public interface IHandle<T> where T : BaseDomainEvent
    {
        // TODO: Make async
        void Handle(T domainEvent);
    }
}
