using Seed.Core.Contracts.UseCases.Crud.Delete;

namespace Seed.Core.Contracts.UseCases.FooUseCases.Delete
{
    public class DeleteFooUseCaseResponse : BaseDeleteUseCaseResponse
    {
        public DeleteFooUseCaseResponse(long id) : base(id)
        {
        }
    }
}
