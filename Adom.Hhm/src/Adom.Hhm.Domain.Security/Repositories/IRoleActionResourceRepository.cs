using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Secutiry.Repositories
{
    public interface IRoleActionResourceRepository
    {
        IEnumerable<RoleActionResource> GetActionsResources();
        RoleActionResource GeRoleActionResource(int roleId, int actionResourceId);
        IEnumerable<RoleActionResource> GeRoleActionsResourcesByRoleId(int roleId);
        bool Insert(RoleActionResource roleActionResource);
        bool Delete(RoleActionResource roleActionResource);
    }
}
