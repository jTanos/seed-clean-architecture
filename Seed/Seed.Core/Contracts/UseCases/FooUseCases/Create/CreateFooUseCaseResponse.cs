using Seed.Core.Contracts.UseCases.Crud.Create;

namespace Seed.Core.Contracts.UseCases.FooUseCases.Create
{
    public class CreateFooUseCaseResponse : BaseCreateUseCaseResponse
    {
        public CreateFooUseCaseResponse(long id) : base(id){
           
        }
    }
}
