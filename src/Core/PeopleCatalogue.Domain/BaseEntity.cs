using ContactsBook.Domain.Events;

namespace ContactsBook.Domain
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}
