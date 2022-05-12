using System.Data;

namespace Seed.Core.Contracts.Repositories.SqlEngineSpecifications
{
    public interface ISqlEngineSpecifications
    {
        IDbConnection CreateAndOpenConnection();

        string LastIdentityValueInsertedQuery();
    }
}
