using Adom.Hhm.AppServices.Security.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adom.Hhm.Domain.Entities.Security;
using System.Security.Claims;
using Adom.Hhm.Domain.Services.Security.Interface;
using Microsoft.AspNetCore.Authorization;

namespace Adom.Hhm.AppServices.Security
{
    public class AuthorizationAppService : IAuthorizationAppService
    {
        private readonly IAuthorizationDomainServices service;

        public AuthorizationAppService(IAuthorizationDomainServices service)
        {
            this.service = service;
        }

        public Action<AuthorizationOptions> GetPolicies()
        {
            return this.service.GetPolicies();
        }

        public IEnumerable<Policy> GetPoliciesByUser(User user)
        {
            return this.service.GetPoliciesByUser(user);
        }

        public bool IsAuthorized(int userId, string route)
        {
            return this.service.IsAuthorized(userId, route);
        }
    }
}
