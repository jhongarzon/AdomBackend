using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Secutiry.Repositories
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetRoles(int pageNumber, int pageSize);
        IEnumerable<Role> GetRoles();
        Role GetRoleById(int RoleId);
        Role GetRoleByName(string name);
        Role GetRoleByNameWithoutId(int RoleId, string name);
        Role Insert(Role Role);
        bool Update(Role Role);
    }
}
