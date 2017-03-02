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
    public interface IRoleAppService
    {
        ServiceResult<IEnumerable<Role>> GetRoles(int pageNumber, int pageSize);
        ServiceResult<Role> GetRoleById(int roleId);
        ServiceResult<Role> Insert(Role role);
        ServiceResult<Role> Update(Role role);
    }
}
