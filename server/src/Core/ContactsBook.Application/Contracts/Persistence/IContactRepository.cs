using ContactsBook.Domain;
using ContactsBook.Domain.Interfaces;

namespace ContactsBook.Application.Contracts.Persistence
{
    public interface IContactRepository : IGenericRepository<Contact>
    {

    }
}
