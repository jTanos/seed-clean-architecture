using System.Collections.Generic;
using System.Threading.Tasks;
using Seed.Core.Contracts.Entities;

namespace Seed.Core.Contracts.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        long Add(T entity);

        Task<long> AddAsync(T entity);

        long Add(IEnumerable<T> entities);

        Task<long> AddAsync(IEnumerable<T> entities);

        bool Update(T entity);

        Task<bool> UpdateAsync(T entity);

        bool Update(IEnumerable<T> entities);

        Task<bool> UpdateAsync(IEnumerable<T> entities);

        bool Delete(T entity);

        Task<bool> DeleteAsync(T entity);

        bool Delete(IEnumerable<T> entities);

        Task<bool> DeleteAsync(IEnumerable<T> entities);

        T GetById(long id);

        Task<T> GetByIdAsync(long id);

        IEnumerable<T> GetByIds(IEnumerable<long> ids);

        Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<long> ids);

        IEnumerable<T> GetAllPaginated(int pageSize, int page);

        Task<IEnumerable<T>> GetAllPaginatedAsync(int pageSize, int page);

        IEnumerable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync();

        bool Exists(long id);

        Task<bool> ExistsAsync(long id);
    }
}
