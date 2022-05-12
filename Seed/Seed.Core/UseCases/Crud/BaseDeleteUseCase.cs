using System.Collections.Generic;
using System.Threading.Tasks;
using Seed.Core.Contracts.Entities;
using Seed.Core.Contracts.Repositories;
using Seed.Core.Contracts.UseCases;
using Seed.Core.Contracts.UseCases.Crud.Delete;

namespace Seed.Core.UseCases.Crud
{
    public class BaseDeleteUseCase<T> : IUseCase<BaseDeleteUseCaseRequest<T>, BaseDeleteUseCaseResponse> where T : class, IEntity
    {
        private readonly IRepository<T> _repository;

        public BaseDeleteUseCase(IRepository<T> repository)
        {
            _repository = repository;
        }

        public void Execute(BaseDeleteUseCaseRequest<T> useCaseRequest, IOutputPort<BaseDeleteUseCaseResponse> outputPort)
        {
            var deleted = _repository.Delete(useCaseRequest.Entity);

            if (!deleted)
            {
                outputPort.HandleError(new List<UseCaseError> { new UseCaseError(1, "Delete Not Found") });
            }

            var deleteFooUseCaseResponse = new BaseDeleteUseCaseResponse(useCaseRequest.Entity.Id);

            outputPort.HandleSuccess(deleteFooUseCaseResponse);
        }

        public async Task ExecuteAsync(BaseDeleteUseCaseRequest<T> useCaseRequest, IOutputPort<BaseDeleteUseCaseResponse> outputPort)
        {
           
            var deleted = await _repository.DeleteAsync(useCaseRequest.Entity);

            if (!deleted)
            {
                outputPort.HandleError(new List<UseCaseError> { new UseCaseError(1, "Delete Not Found") });
            }

            var deleteFooUseCaseResponse = new BaseDeleteUseCaseResponse(useCaseRequest.Entity.Id);

            outputPort.HandleSuccess(deleteFooUseCaseResponse);
        }
    }
}
