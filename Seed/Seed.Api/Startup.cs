using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Seed.Api.FileStorages;
using Seed.Core.Contracts.FileStorages;
using Seed.Core.Contracts.Repositories.FooRepositoryContracts;
using Seed.Core.Contracts.Repositories.SqlEngineSpecifications;
using Seed.Core.Contracts.UseCases.FooUseCases.Create;
using Seed.Core.Contracts.UseCases.FooUseCases.Delete;
using Seed.Core.Contracts.UseCases.FooUseCases.GetAll;
using Seed.Core.Contracts.UseCases.FooUseCases.GetById;
using Seed.Core.Contracts.UseCases.FooUseCases.Update;
using Seed.Core.UseCases.Crud;
using Seed.Infrastructure.FileStorages;
using Seed.Infrastructure.Repositories.Dapper.FooDapperRepositories;
using Seed.Infrastructure.Repositories.SqlEngineSpecifications;

namespace Seed.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Repositories
            services.AddScoped<ISqlServerEngineSpecifications>(s => new SqlServerEngineSpecifications(""));
            services.AddScoped<IFooRepository, FooSqlServerDapperRepository>();

            // UseCases
            services.AddScoped<IGetByIdFooUseCase, BaseGetByIdUseCase>();
            services.AddScoped<IGetAllFooUseCase, BaseGetAllUseCase>();
            services.AddScoped<ICreateFooUseCase, BaseCreateUseCase>();
            services.AddScoped<IUpdateFooUseCase, BaseUpdateUseCase>();
            services.AddScoped<IDeleteFooUseCase, BaseDeleteUseCase>();

            // Storages
            services.AddScoped<ConfigurationsFileStorageSourceGetter, ConfigurationsFileStorageSourceGetter>();
            services.AddScoped<BusinessTextsFileStorageSourceGetter, BusinessTextsFileStorageSourceGetter>();
            services.AddScoped<RoutesFileStorageSourceGetter, RoutesFileStorageSourceGetter>();
            services.AddSingleton<IFileStorage, FileStorage>();

            services.AddControllers(
                options => options.SuppressAsyncSuffixInActionNames = false
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ////app.UseHttpsRedirection();

            app.UseRouting();

            ////app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
