using Microsoft.Extensions.DependencyInjection;
using Product.Core.Services;
using Product.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Core.Dependency
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
