using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Secutiry.Repositories
{
    public interface IAuthenticationRepository
    {
        User ValidCredentials(string email, string password);
    }
}
