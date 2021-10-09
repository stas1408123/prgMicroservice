using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.DAL.Repositories.Implementations;
using ShoppingCart.DAL.Repositories.Interfaces;

namespace ShoppingCart.DAL.Dependency
{
    public static class DataRegistry
    {
        public static void AddDataDependencies(this IServiceCollection services)
        {
            services.AddTransient<IShopCartRepository, ShopCartRepository>();
        }
    }
}
