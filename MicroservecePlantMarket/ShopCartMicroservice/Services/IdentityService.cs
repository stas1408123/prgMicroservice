using Microsoft.AspNetCore.Http;
using ShoppingCart.Api.Services.Interfaces;
using System;

namespace ShoppingCart.Api.Services
{
    internal class IdentityService : IIdentityService    
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
