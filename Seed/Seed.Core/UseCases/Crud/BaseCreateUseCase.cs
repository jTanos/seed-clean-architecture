using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Seed.Core.Contracts.Entities;
using Seed.Core.Contracts.Repositories;
using Seed.Core.Contracts.UseCases;
using Seed.Core.Contracts.UseCases.Crud.Create;

namespace Seed.Core.UseCases.Crud
{
    public class BaseCreateUseCase<T> : IUseCase<IBaseCreateUseCaseRequest<T>, BaseCreateUseCaseResponse> where T :  class, IEntity 
    {
        private readonly IRepository<T> _repository;

        public BaseCreateUseCase(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual void Execute(IBaseCreateUseCaseRequest<T> useCaseRequest, IOutputPort<BaseCreateUseCaseResponse> outputPort)
        {
            var id = _repository.Add(useCaseRequest.Entity);

            if (id == default(long))
            {
                outputPort.HandleError(new List<UseCaseError> { new UseCaseError(1, "Add Not Found") });
            }

            var baseCreateUseCaseResponse = new BaseCreateUseCaseResponse(id);

            outputPort.HandleSuccess(baseCreateUseCaseResponse);
        }

        public virtual async Task ExecuteAsync(IBaseCreateUseCaseRequest<T> useCaseRequest, IOutputPort<BaseCreateUseCaseResponse> outputPort)
        {
            var id = await _repository.AddAsync(useCaseRequest.Entity);

            if (id == default(long))
            {
                outputPort.HandleError(new List<UseCaseError> { new UseCaseError(1, "Add Not Found") });
            }

            var createFooUseCaseResponse = new BaseCreateUseCaseResponse(id);

            outputPort.HandleSuccess(createFooUseCaseResponse);
        }
    }
}
