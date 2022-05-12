namespace Seed.Core.Contracts.UseCases.Crud.Create
{
    public class BaseCreateUseCaseResponse : IUseCaseResponse
    {
        public long Id { get; set; }

        public BaseCreateUseCaseResponse(long id)
        {
            Id = id;
        }
    }
}
