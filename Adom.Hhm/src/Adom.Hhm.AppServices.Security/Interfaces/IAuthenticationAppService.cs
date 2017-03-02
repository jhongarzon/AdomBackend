using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Adom.Hhm.AppServices.Security.Interfaces
{
    public interface IAuthenticationAppService
    {
        Task<object> GetNewToken(User user);
        User ValidCredentials(string email, string password);
    }
}
