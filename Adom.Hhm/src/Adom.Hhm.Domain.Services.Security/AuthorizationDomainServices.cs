using Adom.Hhm.Domain.Services.Security.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adom.Hhm.Domain.Entities.Security;
using System.Security.Claims;
using Adom.Hhm.Domain.Secutiry.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Adom.Hhm.Domain.Services.Security
{
    public class AuthorizationDomainServices : IAuthorizationDomainServices
    {
        private readonly IAuthorizationRepository repository;

        public AuthorizationDomainServices(IAuthorizationRepository repository)
        {
            this.repository = repository;
        }

        public Action<AuthorizationOptions> GetPolicies()
        {
            Action<AuthorizationOptions> options = new Action<AuthorizationOptions>(option =>
            {
                foreach (var policy in this.repository.GetPolicies())
                {
                    option.AddPolicy(policy.Route, policyVar => policyVar.RequireClaim(policy.ResourceName, policy.ActionName));
                }
            });

            return options;
        }

        public IEnumerable<Policy> GetPoliciesByUser(User user)
        {
            return this.repository.GetPoliciesByUser(user);
        }

        public bool IsAuthorized(int userId, string route)
        {
            return this.repository.IsAuthorized(userId, route);
        }
    }
}