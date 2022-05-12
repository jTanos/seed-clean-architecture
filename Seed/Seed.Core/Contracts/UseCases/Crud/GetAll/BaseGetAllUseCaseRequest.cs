using Seed.Core.Contracts.Entities;

namespace Seed.Core.Contracts.UseCases.Crud.GetAll
{
    public abstract class BaseGetAllUseCaseRequest<T> : IUseCaseRequest where T : class, IEntity
    {
      
    }
}