using System.Collections.Generic;
using Seed.Core.Entities;

namespace Seed.Core.Contracts.Repositories.FooRepositoryContracts
{
    public interface IFooRepository : IRepository<Foo>
    {
        IEnumerable<Foo> GetByTitle(string title);
    }
}
