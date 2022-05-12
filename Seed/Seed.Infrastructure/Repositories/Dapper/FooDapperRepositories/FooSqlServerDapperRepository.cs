using System.Collections.Generic;
using Dapper;
using Seed.Core.Contracts.Repositories.FooRepositoryContracts;
using Seed.Core.Contracts.Repositories.SqlEngineSpecifications;
using Seed.Core.Entities;

// ReSharper disable RedundantAnonymousTypePropertyName

namespace Seed.Infrastructure.Repositories.Dapper.FooDapperRepositories
{
    public class FooSqlServerDapperRepository : SqlServerDapperRepository<Foo>, IFooRepository
    {
        private readonly ISqlServerEngineSpecifications _sqlServerEngineSpecifications;

        public FooSqlServerDapperRepository(ISqlServerEngineSpecifications sqlServerEngineSpecifications) : base(sqlServerEngineSpecifications)
        {
            _sqlServerEngineSpecifications = sqlServerEngineSpecifications;
        }

        public IEnumerable<Foo> GetByTitle(string title)
        {
            IEnumerable<Foo> allEntities;

            using (var cn = _sqlServerEngineSpecifications.CreateAndOpenConnection())
            {
                var query = $"SELECT f.Id, f.Title FROM {typeof(Foo).Name}s f WHERE f.Title = @title";

                var queryParams = new
                {
                    title = title
                };

                allEntities = cn.Query<Foo>(query, queryParams);
            }

            return allEntities;
        }
    }
}
