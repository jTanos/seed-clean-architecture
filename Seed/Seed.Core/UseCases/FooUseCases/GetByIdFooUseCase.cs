using Seed.Core.Contracts.Repositories;
using Seed.Core.Contracts.UseCases.FooUseCases.GetById;
using Seed.Core.Entities;
using Seed.Core.UseCases.Crud;

namespace Seed.Core.UseCases.FooUseCases
{
    public class GetByIdFooUseCase : BaseGetByIdUseCase<Foo>, IGetByIdFooUseCase
    {
        public GetByIdFooUseCase(IRepository<Foo> repository) : base(repository)
        {
        }
    }
}