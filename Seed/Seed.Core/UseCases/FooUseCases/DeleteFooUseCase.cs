using Seed.Core.Contracts.Repositories;
using Seed.Core.Contracts.UseCases.FooUseCases.Delete;
using Seed.Core.Entities;
using Seed.Core.UseCases.Crud;

namespace Seed.Core.UseCases.FooUseCases
{
    public class DeleteFooUseCase : BaseDeleteUseCase<Foo>, IDeleteFooUseCase
    {
        public DeleteFooUseCase(IRepository<Foo> repository) : base(repository)
        {
        }
    }
}
