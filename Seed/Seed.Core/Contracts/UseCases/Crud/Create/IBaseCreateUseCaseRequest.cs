using Seed.Core.Contracts.Entities;

namespace Seed.Core.Contracts.UseCases.Crud.Create
{
    public interface IBaseCreateUseCaseRequest<out T> : IUseCaseRequest where T : class, IEntity
    {
        T Entity { get; }
    }
}