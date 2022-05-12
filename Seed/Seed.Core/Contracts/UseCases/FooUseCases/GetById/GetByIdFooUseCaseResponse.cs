using Seed.Core.Contracts.UseCases.Crud.GetById;
using Seed.Core.Entities;

namespace Seed.Core.Contracts.UseCases.FooUseCases.GetById
{
    public class GetByIdFooUseCaseResponse : BaseGetByIdUseCaseResponse<Foo>
    {
        public GetByIdFooUseCaseResponse(Foo foo) : base(foo)
        {
        }
    }
}
