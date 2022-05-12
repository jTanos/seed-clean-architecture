namespace Seed.Core.Contracts.UseCases.Crud.Update
{
    public class BaseUpdateUseCaseResponse : IUseCaseResponse
    {
        public long Id { get; }

        public BaseUpdateUseCaseResponse(long id)
        {
            Id = id;
        }
    }
}
