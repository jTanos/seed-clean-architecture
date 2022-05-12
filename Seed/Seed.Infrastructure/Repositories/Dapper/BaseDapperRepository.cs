using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Seed.Core.Contracts.Entities;
using Seed.Core.Contracts.Repositories;
using Seed.Core.Contracts.Repositories.SqlEngineSpecifications;

namespace Seed.Infrastructure.Repositories.Dapper
{
    public abstract class BaseDapperRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly ISqlEngineSpecifications _sqlEngineSpecifications;

        protected BaseDapperRepository(ISqlEngineSpecifications sqlEngineSpecifications)
        {
            _sqlEngineSpecifications = sqlEngineSpecifications;
        }

        public virtual long Add(T entity)
        {
            long entityId;

            using (var cn = _sqlEngineSpecifications.CreateAndOpenConnection())
            {
                entityId = cn.Insert(entity);
            }

            return entityId;
        }

        public virtual async Task<long> AddAsync(T entity)
        {
            long entityId;

            using (var cn = _sqlEngineSpecifications.CreateAndOpenConnection())
            {
                entityId = await cn.InsertAsync(entity);
            }

            return entityId;
        }

        public virtual long Add(IEnumerable<T> entities)
        {
            long numberOfInsertedRows;

            using (var cn = _sqlEngineSpecifications.CreateAndOpenConnection())
            {
                numberOfInsertedRows = cn.Insert(entities);
            }

            return numberOfInsertedRows;
        }

        public virtual async Task<long> AddAsync(IEnumerable<T> entities)
        {
            long numberOfInsertedRows;

            using (var cn = _sqlEngineSpecifications.CreateAndOpenConnection())
            {
                numberOfInsertedRows = await cn.InsertAsync(entities);
            }

            return numberOfInsertedRows;
        }

        public virtual bool Update(T entity)
        {
            bool updated;

            using (var cn = _sqlEngineSpecifications.CreateAndOpenConnection())
            {
                updated = cn.Update(entity);
            }

            return updated;
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            bool updated;

            using (var cn = _sqlEngineSpecifications.CreateAndOpenConnection())
            {
                updated = await cn.UpdateAsync(entity);
            }

            return updated;
        }

        public virtual bool Update(IEnumerable<T> entities)
        {
            bool updated;

            using (var cn = _sqlEngineSpecifications.CreateAndOpenConnection())
            {
                updated = cn.Update(entities);
            }

            return updated;
        }

        public virtual async Task<bool> UpdateAsync(IEnumerable<T> entities)
        {
            bool updated;

            using (var cn = _sqlEngineSpecifications.CreateAndOpenConnection())
            {
                updated = await cn.UpdateAsync(entities);
            }

            return updated;
        }

        public virtual bool Delete(T entity)
        {
            bool deleted;

            using (var cn = _sqlEngineSpecifications.CreateAndOpenConnection())
            {
                deleted = cn.Delete(entity);
            }

            return deleted;
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            bool deleted;

            using (var cn = _sqlEngineSpecifications.CreateAndOpenConnection())
            {
                deleted = await cn.DeleteAsync(entity);
            }

            return deleted;
        }

        public virtual bool Delete(IEnumerable<T> entities)
        {
            bool deleted;

            using (var cn = _sqlEngineSpecifications.CreateAndOpenConnection())
            {
                deleted = cn.Delete(entities);
            }

            return deleted;
        }

        public virtual async Task<bool> DeleteAsync(IEnumerable<T> entities)
        {
            bool deleted;

            using (var cn = _sqlEngineSpecifications.CreateAndOpenConnection())
            {
                deleted = await cn.DeleteAsync(entities);
            }

            return deleted;
        }

        public virtual T GetById(long id)
        {
            T entity;

            using (var cn = _sqlEngineSpecifications.CreateAndOpenConnection())
            {
                entity = cn.Get<T>(id);
            }

            return entity;
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            T entity;

            using (var cn = _sqlEngineSpecifications.CreateAndOpenConnection())
            {
                entity = await cn.GetAsync<T>(id);
            }

            return entity;
        }

        public abstract IEnumerable<T> GetByIds(IEnumerable<long> ids);

        public abstract Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<long> ids);

        public abstract IEnumerable<T> GetAllPaginated(int pageSize, int page);

        public abstract Task<IEnumerable<T>> GetAllPaginatedAsync(int pageSize, int page);

        public virtual IEnumerable<T> GetAll()
        {
            IEnumerable<T> allEntities;

            using (var cn = _sqlEngineSpecifications.CreateAndOpenConnection())
            {
                allEntities = cn.GetAll<T>();
            }

            return allEntities;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            IEnumerable<T> allEntities;

            using (var cn = _sqlEngineSpecifications.CreateAndOpenConnection())
            {
                allEntities = await cn.GetAllAsync<T>();
            }

            return allEntities;
        }

        public abstract bool Exists(long id);

        public abstract Task<bool> ExistsAsync(long id);
    }
}