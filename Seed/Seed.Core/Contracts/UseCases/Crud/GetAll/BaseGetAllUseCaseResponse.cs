using System.Collections.Generic;
using Seed.Core.Contracts.Entities;

namespace Seed.Core.Contracts.UseCases.Crud.GetAll
{
    public class BaseGetAllUseCaseResponse<T> : IUseCaseResponse where T : class, IEntity
    {
        public IEnumerable<T> Entities { get; set; }

        public BaseGetAllUseCaseResponse(IEnumerable<T> entities)
        {
            Entities = entities;
        }
    }
}
