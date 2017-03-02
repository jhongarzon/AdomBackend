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
    public class RoleAppService : IRoleAppService
    {
        private readonly IRoleDomainServices service;

        public RoleAppService(IRoleDomainServices service)
        {
            this.service = service;
        }

        public ServiceResult<Role> GetRoleById(int roleId)
        {
            return this.service.GetRoleById(roleId);
        }

        public ServiceResult<IEnumerable<Role>> GetRoles(int pageNumber, int pageSize)
        {
            return this.service.GetRoles(pageNumber, pageSize);
        }

        public ServiceResult<Role> Insert(Role role)
        {
            return this.service.Insert(role);
        }

        public ServiceResult<Role> Update(Role role)
        {
            return this.service.Update(role);
        }
    }
}
