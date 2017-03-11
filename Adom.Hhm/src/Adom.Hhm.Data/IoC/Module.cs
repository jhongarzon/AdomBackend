﻿using Adom.Hhm.Data.Repositories;
using Adom.Hhm.Domain.Secutiry.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adom.Hhm.Domain.Security.Repositories;
using Adom.Hhm.Domain.Repositories;

namespace Adom.Hhm.Data.IoC
{
    public static class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dic = new Dictionary<Type, Type>
            {
                {typeof (IAuthenticationRepository), typeof (AuthenticationRepository)},
                {typeof (IAuthorizationRepository), typeof (AuthorizationRepository)},
                {typeof (IUserRepository), typeof (UserRepository)},
                {typeof (IRoleRepository), typeof (RoleRepository)},
                {typeof (IUserRoleRepository), typeof (UserRoleRepository)},
                {typeof (IRoleActionResourceRepository), typeof (RoleActionResourceRepository)},
                {typeof (IProfessionalRepository), typeof (ProfessionalRepository)},
                {typeof (IParameterRepository), typeof (ParameterRepository)},
                {typeof (IPatientRepository), typeof (PatientRepository)}
            };
            return dic;
        }
    }
}
