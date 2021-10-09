using Microsoft.Extensions.DependencyInjection;
using Product.BLL.Services;
using Product.BLL.Services.Interfaces;

namespace Product.BLL.Dependency
{
    public static class BusinessRegistry
    {
        public static void AddBusinessDependencies(this IServiceCollection services)
        {
            services.AddTransient<IPlantService, PlantService>();

            services.AddTransient<ICategoryService, CategoryService>();
        }
    }
}
