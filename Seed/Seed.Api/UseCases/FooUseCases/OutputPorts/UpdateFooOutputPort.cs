using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Seed.Core.Contracts.UseCases;
using Seed.Core.Contracts.UseCases.FooUseCases.Update;

namespace Seed.Api.UseCases.FooUseCases.OutputPorts
{
    public class UpdateFooOutputPort : IOutputPort<UpdateFooUseCaseResponse>
    {
        public IActionResult Result { get; private set; }

        public void HandleSuccess(UpdateFooUseCaseResponse useCaseSuccessResponse)
        {
            Result = new OkObjectResult(useCaseSuccessResponse.Id);
        }

        public void HandleError(IEnumerable<UseCaseError> errors)
        {
            throw new NotImplementedException();
        }
    }
}

