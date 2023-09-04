using ContactsBook.Domain;

namespace ContactsBook.Domain.Interfaces
{
    public interface IGenericRepository<T>
        where T : BaseEntity
    {
        Task<T?> GetAsync(int id);
        Task<IReadOnlyList<T>> GetAsync();
        Task<IReadOnlyList<T>> GetAsync(params string[] includes);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task SaveAsync();
    }
}
