namespace Seed.Core.Contracts.UseCases
{
    public class UseCaseError
    {
        public int Code { get; }

        public string Message { get; }

        public UseCaseError(int code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
