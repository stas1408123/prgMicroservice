using Microsoft.Extensions.DependencyInjection;
using Product.Infrastructure.Repositories.Implementations;
using Product.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Dependency
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
