using Seed.Core.Contracts.Entities;

namespace Seed.Core.Contracts.UseCases.Crud.Delete
{
    public abstract class BaseDeleteUseCaseRequest<T> : IUseCaseRequest where T : class, IEntity
    {
        internal T Entity { get; set; }
    }
}