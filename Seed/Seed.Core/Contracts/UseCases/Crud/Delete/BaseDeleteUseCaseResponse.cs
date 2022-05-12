namespace Seed.Core.Contracts.UseCases.Crud.Delete
{
    public class BaseDeleteUseCaseResponse : IUseCaseResponse
    {
        public long Id { get; }

        public BaseDeleteUseCaseResponse(long id)
        {
            Id = id;
        }
    }
}
