using Microsoft.AspNetCore.Http;
using ShoppingCart.Core.Interfaces;
using System;

namespace ShoppingCart.Core.Dependency
{
    internal class IdentityService : IIdentityService    // выкинуть в Api
    {
        private readonly IHttpContextAccessor _context;

        public IdentityService(IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public string GetUserIdentity()
        {
            return _context.HttpContext.User.FindFirst("sub").Value;
        }
    }
}
