using Seed.Core.Contracts.Entities;

namespace Seed.Core.Contracts.UseCases.Crud.Update
{
    public abstract class BaseUpdateUseCaseRequest<T> : IUseCaseRequest where T : class, IEntity
    {
        internal T Entity { get; set; }
    }
}