using PeopleCatalogue.Application.Contracts.Persistence;
using PeopleCatalogue.Domain;
using PeopleCatalogue.Persistence.DatabaseContext;

namespace PeopleCatalogue.Persistence.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(PeopleDatabaseContext context)
            : base(context)
        {
        }
    }
}
