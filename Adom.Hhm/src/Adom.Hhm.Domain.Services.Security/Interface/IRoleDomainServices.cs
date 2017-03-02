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
    public interface IRoleDomainServices
    {
        ServiceResult<IEnumerable<Role>> GetRoles(int pageNumber, int pageSize);
        ServiceResult<Role> GetRoleById(int userId);
        ServiceResult<Role> Insert(Role user);
        ServiceResult<Role> Update(Role user);
    }
}
