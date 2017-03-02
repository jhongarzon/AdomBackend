using Adom.Hhm.Domain.Services.Security;
using Adom.Hhm.Domain.Services.Security.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Services.Security.IoC
{
    public static class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dic = new Dictionary<Type, Type>();
            dic.Add(typeof(IAuthenticationDomainService), typeof(AuthenticationDomainServices));
            dic.Add(typeof(IAuthorizationDomainServices), typeof(AuthorizationDomainServices));
            dic.Add(typeof(IUserDomainServices), typeof(UserDomainServices));
            dic.Add(typeof(IRoleDomainServices), typeof(RoleDomainServices));
            dic.Add(typeof(IUserRoleDomainServices), typeof(UserRoleDomainServices));
            dic.Add(typeof(IRoleActionResourceDomainServices), typeof(RoleActionResourceDomainServices));
            return dic;
        }
    }
}
