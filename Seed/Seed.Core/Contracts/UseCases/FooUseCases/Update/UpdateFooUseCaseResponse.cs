using Seed.Core.Contracts.UseCases.Crud.Update;

namespace Seed.Core.Contracts.UseCases.FooUseCases.Update
{
    public class UpdateFooUseCaseResponse : BaseUpdateUseCaseResponse
    {
        public UpdateFooUseCaseResponse(long id) : base(id)
        {
        }
    }
}
