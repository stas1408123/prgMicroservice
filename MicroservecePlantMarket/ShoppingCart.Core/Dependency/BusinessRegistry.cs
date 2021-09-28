using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Core.Interfaces;
using ShoppingCart.Core.Services;

namespace ShoppingCart.Core.Dependency
{
    public static class BusinessRegistry
    {
        public static void AddBusinessDependencies(this IServiceCollection services)
        {
            services.AddTransient<IShopCartService, ShopCartService>();
            services.AddTransient<IIdentityService, IdentityService>();
        }
    }
}
