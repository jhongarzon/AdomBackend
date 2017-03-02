using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Services.Security.Interface
{
    public interface IAuthenticationDomainService
    {
        string GetNewToken(User user);
        User ValidCredentials(string email, string password);
    }
}
