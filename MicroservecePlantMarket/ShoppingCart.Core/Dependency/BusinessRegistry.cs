using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.BLL.Interfaces;
using ShoppingCart.BLL.Services;

namespace ShoppingCart.BLL.Dependency
{
    public static class BusinessRegistry
    {
        public static void AddBusinessDependencies(this IServiceCollection services)
        {
            services.AddTransient<IShopCartService, ShopCartService>();
        }
    }
}
