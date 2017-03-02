using Adom.Hhm.AppServices.Security.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adom.Hhm.Domain.Entities.Security;
using System.Security.Claims;
using Adom.Hhm.Domain.Services.Security.Interface;

namespace Adom.Hhm.AppServices.Security
{
    public class RoleActionResourceAppService : IRoleActionResourceAppService
    {
        private readonly IRoleActionResourceDomainServices service;

        public RoleActionResourceAppService(IRoleActionResourceDomainServices service)
        {
            this.service = service;
        }

        public ServiceResult<IEnumerable<RoleActionResource>> GetRoleActionsResourcesByRole(int roleId)
        {
            return this.service.GetRoleActionsResourcesByRole(roleId);
        }

        public ServiceResult<bool> ManagerRoleActionsResources(RoleActionResource roleActionResource)
        {
            return this.service.ManagerRoleActionsResources(roleActionResource);
        }
    }
}
