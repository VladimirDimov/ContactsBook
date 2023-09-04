using ContactsBook.Application.Contracts.Persistence;
using ContactsBook.Domain;
using ContactsBook.Persistence.DatabaseContext;

namespace ContactsBook.Persistence.Repositories
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        public ContactRepository(ContactsBookDatabaseContext context)
            : base(context)
        {
        }
    }
}
