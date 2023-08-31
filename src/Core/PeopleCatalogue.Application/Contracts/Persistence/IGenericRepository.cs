using ContactsBook.Domain;

namespace ContactsBook.Application.Contracts.Persistence
{
    public interface IGenericRepository<T>
        where T : BaseEntity
    {
        Task<T?> GetAsync(int id);
        Task<IReadOnlyList<T>> GetAsync();
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
