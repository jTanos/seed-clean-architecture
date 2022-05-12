using System.Threading.Tasks;

namespace Seed.Core.Contracts.UseCases
{
    public interface IUseCase<in T, out T2> where T : IUseCaseRequest where T2 : IUseCaseResponse
    {
        void Execute(T useCaseRequest, IOutputPort<T2> outputPort);
        Task ExecuteAsync(T useCaseRequest, IOutputPort<T2> outputPort);
    }
}
