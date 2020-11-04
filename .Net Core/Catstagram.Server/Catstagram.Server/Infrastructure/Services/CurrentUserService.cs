using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace Catstagram.Server.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly ClaimsPrincipal user;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            this.user = httpContextAccessor.HttpContext?.User;
        }
        public string GetId()
            => this.user
            .GetId();
        public string GetUserName()
        => this.user
            ?.Identity
            ?.Name;
    }
}
