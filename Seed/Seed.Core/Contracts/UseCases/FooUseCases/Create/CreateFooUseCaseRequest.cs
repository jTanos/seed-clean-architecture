using Seed.Core.Contracts.UseCases.Crud.Create;
using Seed.Core.Entities;

namespace Seed.Core.Contracts.UseCases.FooUseCases.Create
{
    public class CreateFooUseCaseRequest : IBaseCreateUseCaseRequest<Foo>
    {
        public Foo Entity { get; }

        public CreateFooUseCaseRequest(string title)
        {
            Entity = new Foo { Title = title };
        }

    }
}
