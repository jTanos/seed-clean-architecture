using System.Collections.Generic;
using System.Threading.Tasks;
using Seed.Core.Contracts.Entities;
using Seed.Core.Contracts.Repositories;
using Seed.Core.Contracts.UseCases;
using Seed.Core.Contracts.UseCases.Crud.GetById;

namespace Seed.Core.UseCases.Crud
{
    public class BaseGetByIdUseCase<T> : IUseCase<BaseGetByIdUseCaseRequest<T>, BaseGetByIdUseCaseResponse<T>> where T : class, IEntity
    {
        private readonly IRepository<T> _repository;

        public BaseGetByIdUseCase(IRepository<T> repository)
        {
            _repository = repository;
        }

        public void Execute(BaseGetByIdUseCaseRequest<T> useCaseRequest, IOutputPort<BaseGetByIdUseCaseResponse<T>> outputPort)
        {
            var entity = _repository.GetById(useCaseRequest.Entity.Id);

            if (entity != null)
            {
                outputPort.HandleError(new List<UseCaseError> { new UseCaseError(1, "Get by Id Not Found") });
            }

            var getByIdFooUseCaseResponse = new BaseGetByIdUseCaseResponse<T>(entity);

            outputPort.HandleSuccess(getByIdFooUseCaseResponse);
        }

        public async Task ExecuteAsync(BaseGetByIdUseCaseRequest<T> useCaseRequest, IOutputPort<BaseGetByIdUseCaseResponse<T>> outputPort)
        {
            var entity = await _repository.GetByIdAsync(useCaseRequest.Entity.Id);

            if (entity != null)
            {
                outputPort.HandleError(new List<UseCaseError> { new UseCaseError(1, "Get by Id Not Found") });
            }

            var getByIdFooUseCaseResponse = new BaseGetByIdUseCaseResponse<T>(entity);

            outputPort.HandleSuccess(getByIdFooUseCaseResponse);
        }
    }
}