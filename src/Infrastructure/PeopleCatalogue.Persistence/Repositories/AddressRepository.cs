using ContactsBook.Application.Contracts.Persistence;
using ContactsBook.Domain;
using ContactsBook.Persistence.DatabaseContext;

namespace ContactsBook.Persistence.Repositories
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(ContactsBookDatabaseContext context)
            : base(context)
        {
        }
    }
}
