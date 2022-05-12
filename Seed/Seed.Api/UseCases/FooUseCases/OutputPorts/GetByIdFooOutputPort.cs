using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Seed.Core.Contracts.UseCases;
using Seed.Core.Contracts.UseCases.FooUseCases.GetById;

namespace Seed.Api.UseCases.FooUseCases.OutputPorts
{
    public class GetByIdFooOutputPort : IOutputPort<GetByIdFooUseCaseResponse>
    {
        public IActionResult Result { get; private set; }

        public void HandleSuccess(GetByIdFooUseCaseResponse useCaseSuccessResponse)
        {
            Result = new OkObjectResult(useCaseSuccessResponse.Entity);
        }

        public void HandleError(IEnumerable<UseCaseError> errors)
        {
            throw new NotImplementedException();
        }
    }
}

