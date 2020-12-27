using FoodApp.Core.Interfaces;
using IdentityModel;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Http;

namespace FoodApp.Services.Accounts
{
    public class TenantProvider : ITenantProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetTenantId()
        {
            if (_httpContextAccessor.HttpContext == null)
            {
                return string.Empty;
            }
            var userId = string.Empty;
            if (_httpContextAccessor.HttpContext.User.IsAuthenticated())
            {
                userId = _httpContextAccessor.HttpContext.User.FindFirst(JwtClaimTypes.Id)?.Value;
            }

            return userId;
        }
    }
}
