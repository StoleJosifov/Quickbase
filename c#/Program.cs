using Backend.Database;
using Backend.Database.Repositories;
using Backend.DomainModels.AutoMapper;
using Backend.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Backend
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddScoped<DatabaseContext>();
            services.AddScoped<IDataRepository, DataRepository>();
            services.AddScoped<IAutoMapperService, AutoMapperService>();
            services.BuildServiceProvider();

            var dbService = new DbStatService(new DbDataService(new DataRepository()), new AutoMapperService());

            var dbTask = dbService.GetCountryPopulationsAsync();
            dbTask.Wait();
            var dbResult = dbTask.Result;
        }
    }
}
