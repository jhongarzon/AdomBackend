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
    public class UserRoleAppService : IUserRoleAppService
    {
        private readonly IUserRoleDomainServices service;

        public UserRoleAppService(IUserRoleDomainServices service)
        {
            this.service = service;
        }

        public ServiceResult<IEnumerable<UserRole>> GetRolesByUserId(int userId)
        {
            return this.service.GetRolesByUserId(userId);
        }

        public ServiceResult<bool> ManagerUserRole(UserRole userRole)
        {
            return this.service.ManagerUserRole(userRole);
        }
    }
}
