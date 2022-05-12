using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Seed.Core.Contracts.Entities;
using Seed.Core.Contracts.Repositories.SqlEngineSpecifications;

// ReSharper disable RedundantAnonymousTypePropertyName

namespace Seed.Infrastructure.Repositories.Dapper
{
    public class SqlServerDapperRepository<T> : BaseDapperRepository<T> where T : class, IEntity
    {
        protected readonly ISqlServerEngineSpecifications SqlServerEngineSpecifications;

        protected SqlServerDapperRepository(ISqlServerEngineSpecifications sqlServerEngineSpecifications) : base(sqlServerEngineSpecifications)
        {
            SqlServerEngineSpecifications = sqlServerEngineSpecifications;
        }

        public override IEnumerable<T> GetByIds(IEnumerable<long> ids)
        {
            var idsList = ids.ToList();

            if (!idsList.Any())
            {
                return default(IEnumerable<T>);
            }

            IEnumerable<T> allEntities;

            using (var cn = SqlServerEngineSpecifications.CreateAndOpenConnection())
            {
                var query = $"SELECT * FROM {typeof(T).Name}s WHERE Id IN @ids";

                var queryParams = new
                {
                    ids = idsList
                };

                allEntities = cn.Query<T>(query, queryParams);
            }

            return allEntities;
        }

        public override async Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<long> ids)
        {
            var idsList = ids.ToList();

            if (!idsList.Any())
            {
                return default(IEnumerable<T>);
            }

            IEnumerable<T> allEntities;

            using (var cn = SqlServerEngineSpecifications.CreateAndOpenConnection())
            {
                var query = $"SELECT * FROM {typeof(T).Name}s WHERE Id IN @ids";

                var queryParams = new
                {
                    ids = idsList
                };

                allEntities = await cn.QueryAsync<T>(query, queryParams);
            }

            return allEntities;
        }

        public override IEnumerable<T> GetAllPaginated(int pageSize, int page)
        {
            IEnumerable<T> allEntities;

            using (var cn = SqlServerEngineSpecifications.CreateAndOpenConnection())
            {
                var query = $"DECLARE @_PageSize INT = @pageSize " +
                            $"DECLARE @_Page INT = @page " +
                            $"SELECT * FROM ( SELECT RowNum = ROW_NUMBER() OVER ( ORDER BY Id), * FROM {typeof(T).Name}s ) AS a WHERE RowNum > (@_PageSize * (@_Page - 1)) AND RowNum <= (@_PageSize * (@_Page - 1)) + @_PageSize ORDER BY Id";

                var queryParams = new
                {
                    pageSize = pageSize,
                    page = page
                };

                allEntities = cn.Query<T>(query, queryParams);
            }

            return allEntities;
        }

        public override async Task<IEnumerable<T>> GetAllPaginatedAsync(int pageSize, int page)
        {
            IEnumerable<T> allEntities;

            using (var cn = SqlServerEngineSpecifications.CreateAndOpenConnection())
            {
                var query = $"DECLARE @_PageSize INT = @pageSize " +
                            $"DECLARE @_Page INT = @page " +
                            $"SELECT * FROM ( SELECT RowNum = ROW_NUMBER() OVER ( ORDER BY Id), * FROM {typeof(T).Name}s ) AS a WHERE RowNum > (@_PageSize * (@_Page - 1)) AND RowNum <= (@_PageSize * (@_Page - 1)) + @_PageSize ORDER BY Id";

                var queryParams = new
                {
                    pageSize = pageSize,
                    page = page
                };

                allEntities = await cn.QueryAsync<T>(query, queryParams);
            }

            return allEntities;
        }

        public sealed override bool Exists(long id)
        {
            long entityId;

            using (var cn = SqlServerEngineSpecifications.CreateAndOpenConnection())
            {
                var query = $"SELECT TOP 1 1 FROM {typeof(T).Name}s WHERE Id = @id";

                var queryParams = new
                {
                    id = id
                };

                entityId = cn.QuerySingleOrDefault<int>(query, queryParams);
            }

            if (entityId == default(long))
            {
                return false;
            }

            return true;
        }

        public sealed override async Task<bool> ExistsAsync(long id)
        {
            long entityId;

            using (var cn = SqlServerEngineSpecifications.CreateAndOpenConnection())
            {
                var query = $"SELECT TOP 1 1 FROM {typeof(T).Name}s WHERE Id = @id";

                var queryParams = new
                {
                    id = id
                };

                entityId = await cn.QuerySingleOrDefaultAsync<int>(query, queryParams);
            }

            if (entityId == default(long))
            {
                return false;
            }

            return true;
        }
    }
}
