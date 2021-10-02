using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Infrastructure.Repositories.Implementations;
using ShoppingCart.Infrastructure.Repositories.Interfaces;

namespace ShoppingCart.Infrastructure.Dependency
{
    public static class DataRegistry
    {
        public static void AddDataDependencies(this IServiceCollection services)
        {
            services.AddTransient<IShopCartRepository, ShopCartRepository>();
        }
    }
}
