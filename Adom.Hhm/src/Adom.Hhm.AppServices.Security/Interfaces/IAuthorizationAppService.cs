using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Adom.Hhm.AppServices.Security.Interfaces
{
    public interface IAuthorizationAppService
    {
        Action<AuthorizationOptions> GetPolicies();
        IEnumerable<Policy> GetPoliciesByUser(User user);
        bool IsAuthorized(int userId, string route);
    }
}
