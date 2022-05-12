using Seed.Core.Contracts.UseCases.Crud.Create;
using Seed.Core.Entities;

namespace Seed.Core.Contracts.UseCases.FooUseCases.Create
{
    public interface ICreateFooUseCase : IUseCase<IBaseCreateUseCaseRequest<Foo>, BaseCreateUseCaseResponse>
    {
    }
}
