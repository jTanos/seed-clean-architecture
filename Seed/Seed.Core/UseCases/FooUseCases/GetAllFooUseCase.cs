using Seed.Core.Contracts.Repositories;
using Seed.Core.Contracts.UseCases.FooUseCases.GetAll;
using Seed.Core.Entities;
using Seed.Core.UseCases.Crud;

namespace Seed.Core.UseCases.FooUseCases
{
    public class GetAllFooUseCase : BaseGetAllUseCase<Foo>, IGetAllFooUseCase
    {
        public GetAllFooUseCase(IRepository<Foo> repository) : base(repository)
        {
        }
    }
}
