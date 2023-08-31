using PeopleCatalogue.Domain;

namespace PeopleCatalogue.Application.Contracts.Persistence
{
    public interface IGenericRepository<T>
        where T : BaseEntity
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<T> GetAsync(int id);
    }
}
