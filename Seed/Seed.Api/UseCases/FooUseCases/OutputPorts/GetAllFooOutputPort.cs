using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Seed.Core.Contracts.UseCases;
using Seed.Core.Contracts.UseCases.FooUseCases.GetAll;

namespace Seed.Api.UseCases.FooUseCases.OutputPorts
{
    public class GetAllFooOutputPort : IOutputPort<GetAllFooUseCaseResponse>
    {
        public IActionResult Result { get; private set; }

        public void HandleSuccess(GetAllFooUseCaseResponse useCaseSuccessResponse)
        {
            Result = new OkObjectResult(useCaseSuccessResponse.Entities);
        }

        public void HandleError(IEnumerable<UseCaseError> errors)
        {
            throw new NotImplementedException();
        }
    }
}

