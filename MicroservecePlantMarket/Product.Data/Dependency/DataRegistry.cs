using Microsoft.Extensions.DependencyInjection;
using Product.DAL.Repositories.Implementations;
using Product.DAL.Repositories.Interfaces;

namespace Product.DAL.Dependency
{
    public static class DataRegistry
    {
        public static void AddDataDependencies(this IServiceCollection services)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services.AddTransient<IPlantRepository, PlantRepository>();
        }
    }
}
