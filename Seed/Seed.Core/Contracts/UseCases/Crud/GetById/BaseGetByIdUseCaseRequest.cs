using Seed.Core.Contracts.Entities;

namespace Seed.Core.Contracts.UseCases.Crud.GetById
{
    public abstract class BaseGetByIdUseCaseRequest<T> : IUseCaseRequest where T : class, IEntity
    {
        internal T Entity { get; set; }
    }
}