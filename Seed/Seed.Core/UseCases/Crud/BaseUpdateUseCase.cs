using System.Collections.Generic;
using System.Threading.Tasks;
using Seed.Core.Contracts.Entities;
using Seed.Core.Contracts.Repositories;
using Seed.Core.Contracts.UseCases;
using Seed.Core.Contracts.UseCases.Crud.Update;

namespace Seed.Core.UseCases.Crud
{
    public class BaseUpdateUseCase<T> : IUseCase<BaseUpdateUseCaseRequest<T>, BaseUpdateUseCaseResponse> where T : class, IEntity
    {
        private readonly IRepository<T> _repository;

        public BaseUpdateUseCase(IRepository<T> repository)
        {
            _repository = repository;
        }

        public void Execute(BaseUpdateUseCaseRequest<T> useCaseRequest, IOutputPort<BaseUpdateUseCaseResponse> outputPort)
        {
            var updated = _repository.Update(useCaseRequest.Entity);

            if (!updated)
            {
                outputPort.HandleError(new List<UseCaseError> { new UseCaseError(1, "Add Not Found") });
            }

            var updateFooUseCaseResponse = new BaseUpdateUseCaseResponse(useCaseRequest.Entity.Id);

            outputPort.HandleSuccess(updateFooUseCaseResponse);
        }

        public async Task ExecuteAsync(BaseUpdateUseCaseRequest<T> useCaseRequest, IOutputPort<BaseUpdateUseCaseResponse> outputPort)
        {
            var updated = await _repository.UpdateAsync(useCaseRequest.Entity);

            if (!updated)
            {
                outputPort.HandleError(new List<UseCaseError> { new UseCaseError(1, "Add Not Found") });
            }

            var updateFooUseCaseResponse = new BaseUpdateUseCaseResponse(useCaseRequest.Entity.Id);

            outputPort.HandleSuccess(updateFooUseCaseResponse);
        }
    }
}
