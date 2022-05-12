using System.Collections.Generic;
using Seed.Core.Contracts.UseCases.Crud.GetAll;
using Seed.Core.Entities;

namespace Seed.Core.Contracts.UseCases.FooUseCases.GetAll
{
    public class GetAllFooUseCaseResponse : BaseGetAllUseCaseResponse<Foo>
    {
        public GetAllFooUseCaseResponse(IEnumerable<Foo> foos) : base(foos)
        {
        }
    }
}
