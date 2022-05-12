using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Seed.Core.Contracts.UseCases;
using Seed.Core.Contracts.UseCases.FooUseCases.Delete;

namespace Seed.Api.UseCases.FooUseCases.OutputPorts
{
    public class DeleteFooOutputPort : IOutputPort<DeleteFooUseCaseResponse>
    {
        public IActionResult Result { get; private set; }

        public void HandleSuccess(DeleteFooUseCaseResponse useCaseSuccessResponse)
        {
            Result = new OkObjectResult(useCaseSuccessResponse.Id);
        }

        public void HandleError(IEnumerable<UseCaseError> errors)
        {
            throw new NotImplementedException();
        }
    }
}

