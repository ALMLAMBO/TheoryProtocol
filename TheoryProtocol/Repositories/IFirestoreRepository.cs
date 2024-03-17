namespace TheoryProtocol.Repositories
{
    public interface IFirestoreRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetByFieldIdAsync(string field,int id);
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
        Task UpdateIdAsync(string collectionName);
        Task<int> GetIdAsync(string collectionName);
    }
}
