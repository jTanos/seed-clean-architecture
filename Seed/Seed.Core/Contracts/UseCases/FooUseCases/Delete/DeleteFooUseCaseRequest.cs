using Seed.Core.Contracts.UseCases.Crud.Delete;
using Seed.Core.Entities;

namespace Seed.Core.Contracts.UseCases.FooUseCases.Delete
{
    public class DeleteFooUseCaseRequest : BaseDeleteUseCaseRequest<Foo>
    {
        public DeleteFooUseCaseRequest(long id)
        {
            Entity = new Foo { Id = id };
        }
    }
}
