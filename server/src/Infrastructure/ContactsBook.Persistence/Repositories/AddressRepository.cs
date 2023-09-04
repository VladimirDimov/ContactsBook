using ContactsBook.Application.Contracts.Persistence;
using ContactsBook.Domain;
using ContactsBook.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace ContactsBook.Persistence.Repositories
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(ContactsBookDatabaseContext context)
            : base(context)
        {
        }

        public async Task<List<Address>> GetByContactId(int contactId)
            => await Set.Where(a => a.ContactId == contactId).ToListAsync();
    }
}
