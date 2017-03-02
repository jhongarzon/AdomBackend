using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Secutiry.Repositories
{
    public interface IUserRoleRepository
    {
        IEnumerable<UserRole> GetRolesByUserId(int userId);
        UserRole GeUserRolByUserIdRoleID(int userId, int roleId); 
        bool Insert(UserRole UserRole);
        bool Delete(UserRole UserRole);
    }
}
