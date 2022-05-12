using System.Collections.Generic;

namespace Seed.Core.Contracts.UseCases
{
    public interface IOutputPort<in T>
    {
        void HandleSuccess(T useCaseSuccessResponse);

        void HandleError(IEnumerable<UseCaseError> errors);
    }
}
