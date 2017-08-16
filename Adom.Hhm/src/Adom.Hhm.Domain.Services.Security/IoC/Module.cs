using System;
using System.Collections.Generic;
using Adom.Hhm.Domain.Services.Security.Interface;

namespace Adom.Hhm.Domain.Services.Security.IoC
{
    public static class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dic = new Dictionary<Type, Type>
            {
                {typeof (IAuthenticationDomainService), typeof (AuthenticationDomainServices)},
                {typeof (IAuthorizationDomainServices), typeof (AuthorizationDomainServices)},
                {typeof (IUserDomainServices), typeof (UserDomainServices)},
                {typeof (IRoleDomainServices), typeof (RoleDomainServices)},
                {typeof (IUserRoleDomainServices), typeof (UserRoleDomainServices)},
                {typeof (IRoleActionResourceDomainServices), typeof (RoleActionResourceDomainServices)}
            };
            return dic;
        }
    }
}
