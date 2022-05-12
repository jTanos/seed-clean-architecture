using Seed.Core.Contracts.Repositories;
using Seed.Core.Contracts.UseCases.FooUseCases.Update;
using Seed.Core.Entities;
using Seed.Core.UseCases.Crud;

namespace Seed.Core.UseCases.FooUseCases
{
    public class UpdateFooUseCase : BaseUpdateUseCase<Foo>, IUpdateFooUseCase
    {
        public UpdateFooUseCase(IRepository<Foo> repository) : base(repository)
        {
        }
    }
}
