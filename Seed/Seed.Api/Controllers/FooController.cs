using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Seed.Api.Dtos.FooDtos;
using Seed.Api.FileStorages;
using Seed.Api.UseCases.FooUseCases.OutputPorts;
using Seed.Core.Contracts.FileStorages;
using Seed.Core.Contracts.UseCases.FooUseCases.Create;
using Seed.Core.Contracts.UseCases.FooUseCases.Delete;
using Seed.Core.Contracts.UseCases.FooUseCases.GetAll;
using Seed.Core.Contracts.UseCases.FooUseCases.GetById;
using Seed.Core.Contracts.UseCases.FooUseCases.Update;

namespace Seed.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FooController : ControllerBase
    {
        private readonly IGetByIdFooUseCase _getByIdFooUseCase;
        private readonly IGetAllFooUseCase _getAllFooUseCase;
        private readonly ICreateFooUseCase _createFooUseCase;
        private readonly IUpdateFooUseCase _updateFooUseCase;
        private readonly IDeleteFooUseCase _deleteFooUseCase;
        private readonly IFileStorage _fileStorage;
        private readonly ConfigurationsFileStorageSourceGetter _configurationsFileStorageSourceGetter;
        private readonly BusinessTextsFileStorageSourceGetter _businessTextsFileStorageSourceGetter;

        public FooController(IGetByIdFooUseCase getByIdFooUseCase,
            IGetAllFooUseCase getAllFooUseCase,
            ICreateFooUseCase createFooUseCase,
            IUpdateFooUseCase updateFooUseCase,
            IDeleteFooUseCase deleteFooUseCase,
            IFileStorage fileStorage,
            ConfigurationsFileStorageSourceGetter configurationsFileStorageSourceGetter,
            BusinessTextsFileStorageSourceGetter businessTextsFileStorageSourceGetter)
        {
            _getByIdFooUseCase = getByIdFooUseCase;
            _getAllFooUseCase = getAllFooUseCase;
            _createFooUseCase = createFooUseCase;
            _updateFooUseCase = updateFooUseCase;
            _deleteFooUseCase = deleteFooUseCase;
            _fileStorage = fileStorage;
            _configurationsFileStorageSourceGetter = configurationsFileStorageSourceGetter;
            _businessTextsFileStorageSourceGetter = businessTextsFileStorageSourceGetter;
        }

        // GET: Foo/GetById/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var getByIdFooUseCaseRequest = new GetByIdFooUseCaseRequest(id);

            var getByIdFooOutputPort = new GetByIdFooOutputPort();

            _getByIdFooUseCase.Execute(getByIdFooUseCaseRequest, getByIdFooOutputPort);

            return getByIdFooOutputPort.Result;
        }

        // GET: Foo/GetByIdAsync/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var getByIdFooUseCaseRequest = new GetByIdFooUseCaseRequest(id);

            var getByIdFooOutputPort = new GetByIdFooOutputPort();

            await _getByIdFooUseCase.ExecuteAsync(getByIdFooUseCaseRequest, getByIdFooOutputPort);

            return getByIdFooOutputPort.Result;
        }

        // GET: Foo/GetAll
        [HttpGet]
        public IActionResult GetAll()
        {
            var s = _fileStorage.GetValue<int>(_configurationsFileStorageSourceGetter, "VideoDownloadSpecification_MaxBitrateKbitps");

            var businessText = _fileStorage.GetValue<string>(_businessTextsFileStorageSourceGetter,
                "ChangeMail_ChangeMailCallbackUnexpectedErrorMessage");

            var getAllFooUseCaseRequest = new GetAllFooUseCaseRequest();

            var getAllFooOutputPort = new GetAllFooOutputPort();

            _getAllFooUseCase.Execute(getAllFooUseCaseRequest, getAllFooOutputPort);

            return getAllFooOutputPort.Result;
        }

        // GET: Foo/GetAllAsync
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAllFooUseCaseRequest = new GetAllFooUseCaseRequest();

            var getAllFooOutputPort = new GetAllFooOutputPort();

            await _getAllFooUseCase.ExecuteAsync(getAllFooUseCaseRequest, getAllFooOutputPort);

            return getAllFooOutputPort.Result;
        }


        // POST: foo/Create
        [HttpPost]
        public IActionResult Create([FromBody] FooCreateDto fooDto)
        {
            //Todo valid model

            var createFooUseCaseRequest = new CreateFooUseCaseRequest(fooDto.Title);

            var createFooOutputPort = new CreateFooOutputPort();

            _createFooUseCase.Execute(createFooUseCaseRequest, createFooOutputPort);

            return createFooOutputPort.Result;
        }


        // POST: foo/CreateAsync
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] FooCreateDto fooDto)
        {
            //Todo valid model

            var createFooUseCaseRequest = new CreateFooUseCaseRequest(fooDto.Title);

            var createFooOutputPort = new CreateFooOutputPort();

            await _createFooUseCase.ExecuteAsync(createFooUseCaseRequest, createFooOutputPort);

            return createFooOutputPort.Result;
        }

        // PUT: foo/Update
        [HttpPut]
        public IActionResult Update([FromBody] FooUpdateDto fooDto)
        {
            //Todo valid model

            var updateFooUseCaseRequest = new UpdateFooUseCaseRequest(fooDto.Id, fooDto.Title);

            var updateFooOutputPort = new UpdateFooOutputPort();

            _updateFooUseCase.Execute(updateFooUseCaseRequest, updateFooOutputPort);

            return updateFooOutputPort.Result;
        }

        // PUT: foo/PutAsync
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] FooUpdateDto fooDto)
        {
            //Todo valid model

            var updateFooUseCaseRequest = new UpdateFooUseCaseRequest(fooDto.Id, fooDto.Title);

            var updateFooOutputPort = new UpdateFooOutputPort();

            await _updateFooUseCase.ExecuteAsync(updateFooUseCaseRequest, updateFooOutputPort);

            return updateFooOutputPort.Result;
        }

        // DELETE: foo/Delete/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var deleteFooUseCaseRequest = new DeleteFooUseCaseRequest(id);

            var deleteFooOutputPort = new DeleteFooOutputPort();

            _deleteFooUseCase.Execute(deleteFooUseCaseRequest, deleteFooOutputPort);

            return deleteFooOutputPort.Result;
        }

        // DELETE: foo/DeleteAsync/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var deleteFooUseCaseRequest = new DeleteFooUseCaseRequest(id);

            var deleteFooOutputPort = new DeleteFooOutputPort();

            await _deleteFooUseCase.ExecuteAsync(deleteFooUseCaseRequest, deleteFooOutputPort);

            return deleteFooOutputPort.Result;
        }
    }
}
