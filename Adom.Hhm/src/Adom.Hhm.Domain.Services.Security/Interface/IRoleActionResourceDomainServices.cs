using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Services.Security.Interface
{
    public interface IRoleActionResourceDomainServices
    {
        ServiceResult<IEnumerable<RoleActionResource>> GetRoleActionsResourcesByRole(int roleId);
        ServiceResult<bool> ManagerRoleActionsResources(RoleActionResource roleActionResource);
    }
}
