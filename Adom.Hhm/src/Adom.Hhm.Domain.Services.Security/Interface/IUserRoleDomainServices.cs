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
    public interface IUserRoleDomainServices
    {
        ServiceResult<IEnumerable<UserRole>> GetRolesByUserId(int userId);
        ServiceResult<bool> ManagerUserRole(UserRole userRole);
    }
}
