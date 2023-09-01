using ContactsBook.Domain.Events;

namespace ContactsBook.Domain.Interfaces
{
    public interface IHandle<T> where T : BaseDomainEvent
    {
        void Handle(T domainEvent);
    }
}
