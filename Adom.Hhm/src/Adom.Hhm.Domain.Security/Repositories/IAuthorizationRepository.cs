using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Secutiry.Repositories
{
    public interface IAuthorizationRepository
    {
        IEnumerable<Policy> GetPolicies();
        IEnumerable<Policy> GetPoliciesByUser(User user);
        bool IsAuthorized(int userId, string route);
    }
}
