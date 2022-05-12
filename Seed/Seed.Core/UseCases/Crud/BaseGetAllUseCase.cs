using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Seed.Core.Contracts.Entities;
using Seed.Core.Contracts.Repositories;
using Seed.Core.Contracts.UseCases;
using Seed.Core.Contracts.UseCases.Crud.GetAll;

namespace Seed.Core.UseCases.Crud
{
    public class BaseGetAllUseCase<T> : IUseCase<BaseGetAllUseCaseRequest<T>, BaseGetAllUseCaseResponse<T>> where T : class, IEntity
    {
        private readonly IRepository<T> _repository;

        public BaseGetAllUseCase(IRepository<T> repository)
        {
            _repository = repository;
        }

        public void Execute(BaseGetAllUseCaseRequest<T> useCaseRequest, IOutputPort<BaseGetAllUseCaseResponse<T>> outputPort)
        {
            var entities = _repository.GetAll();

            if (!entities.Any())
            {
                outputPort.HandleError(new List<UseCaseError> { new UseCaseError(1, "Not Found") });
            }

            var getAllFooUseCaseResponse = new BaseGetAllUseCaseResponse<T>(entities);

            outputPort.HandleSuccess(getAllFooUseCaseResponse);
        }
        
        public async Task ExecuteAsync(BaseGetAllUseCaseRequest<T> useCaseRequest, IOutputPort<BaseGetAllUseCaseResponse<T>> outputPort)
        {
            var entities = await _repository.GetAllAsync();

            if (!entities.Any())
            {
                outputPort.HandleError(new List<UseCaseError> { new UseCaseError(1, "Not Found") });
            }

            var getAllFooUseCaseResponse = new BaseGetAllUseCaseResponse<T>(entities);

            outputPort.HandleSuccess(getAllFooUseCaseResponse);
        }
    }
}
