using Seed.Core.Contracts.Entities;

namespace Seed.Core.Contracts.UseCases.Crud.GetById
{
    public class BaseGetByIdUseCaseResponse<T> : IUseCaseResponse where T : class, IEntity
    {
        public T Entity { get; set; }

        public BaseGetByIdUseCaseResponse(T entity)
        {
            Entity = entity;
        }
    }
}
