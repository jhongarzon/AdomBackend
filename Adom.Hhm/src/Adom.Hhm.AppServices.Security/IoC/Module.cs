using Adom.Hhm.AppServices.Security.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adom.Hhm.AppServices.Security.IoC
{
    public static class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dic = new Dictionary<Type, Type>();
            dic.Add(typeof(IAuthenticationAppService), typeof(AuthenticationAppService));
            dic.Add(typeof(IAuthorizationAppService), typeof(AuthorizationAppService));
            dic.Add(typeof(IUserAppService), typeof(UserAppService));
            dic.Add(typeof(IRoleAppService), typeof(RoleAppService));
            dic.Add(typeof(IUserRoleAppService), typeof(UserRoleAppService));
            dic.Add(typeof(IRoleActionResourceAppService), typeof(RoleActionResourceAppService));
            return dic;
        }
    }
}
