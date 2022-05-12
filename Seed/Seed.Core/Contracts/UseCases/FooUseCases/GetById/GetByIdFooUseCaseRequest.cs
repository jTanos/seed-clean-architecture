using Seed.Core.Contracts.UseCases.Crud.GetById;
using Seed.Core.Entities;

namespace Seed.Core.Contracts.UseCases.FooUseCases.GetById
{
    public class GetByIdFooUseCaseRequest : BaseGetByIdUseCaseRequest<Foo>
    {
        public GetByIdFooUseCaseRequest(long id)
        {
            Entity = new Foo { Id = id };
        }
    }
}
