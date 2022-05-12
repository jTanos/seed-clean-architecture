using Seed.Core.Contracts.UseCases.Crud.Update;
using Seed.Core.Entities;

namespace Seed.Core.Contracts.UseCases.FooUseCases.Update
{
    public class UpdateFooUseCaseRequest : BaseUpdateUseCaseRequest<Foo>
    {
        public UpdateFooUseCaseRequest(long id, string title)
        {
            Entity = new Foo { Id = id, Title = title };
        }
    }
}
