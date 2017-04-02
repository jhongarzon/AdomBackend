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
    public interface IUserDomainServices
    {
        ServiceResult<IEnumerable<User>> GetUsers(int pageNumber, int pageSize);
        ServiceResult<IEnumerable<User>> GetUsers();
        ServiceResult<IEnumerable<User>> GetUsersActive();
        ServiceResult<User> GetUserById(int userId);
        ServiceResult<User> Insert(User user);
        ServiceResult<User> Update(User user);
        ServiceResult<bool> ChangePassword(int userId, string password);
        ServiceResult<User> RecoverPassword(string email);
    }
}
