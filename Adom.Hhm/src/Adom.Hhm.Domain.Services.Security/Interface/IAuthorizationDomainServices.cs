using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Adom.Hhm.Domain.Services.Security.Interface
{
    public interface IAuthorizationDomainServices
    {
        Action<AuthorizationOptions> GetPolicies();
        IEnumerable<Policy> GetPoliciesByUser(User user);
        bool IsAuthorized(int userId, string route);
    }
}
