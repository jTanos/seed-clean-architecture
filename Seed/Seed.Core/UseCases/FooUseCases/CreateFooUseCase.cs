using System.Threading.Tasks;
using Seed.Core.Contracts.Repositories.FooRepositoryContracts;
using Seed.Core.Contracts.UseCases;
using Seed.Core.Contracts.UseCases.FooUseCases.Create;
using Seed.Core.Entities;
using Seed.Core.UseCases.Crud;

namespace Seed.Core.UseCases.FooUseCases
{
    public class CreateFooUseCase : BaseCreateUseCase<Foo>, ICreateFooUseCase
    {
        public CreateFooUseCase(IFooRepository fooRepository) : base(fooRepository)
        {
        }
    }
}
