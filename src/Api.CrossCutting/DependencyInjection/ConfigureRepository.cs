using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection service)
        {
            service.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            service.AddDbContext<MyContext>(o => o.UseInMemoryDatabase("db"));
        }
    }
}
