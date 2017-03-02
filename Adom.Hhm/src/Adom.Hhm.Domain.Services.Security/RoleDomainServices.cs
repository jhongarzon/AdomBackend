using Adom.Hhm.Domain.Services.Security.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adom.Hhm.Domain.Entities.Security;
using System.Security.Claims;
using Adom.Hhm.Domain.Secutiry.Repositories;
using Microsoft.AspNetCore.Authorization;
using Adom.Hhm.Utility;
using Microsoft.Extensions.Configuration;

namespace Adom.Hhm.Domain.Services.Security
{
    public class RoleDomainServices : IRoleDomainServices
    {
        private readonly IRoleRepository repository;
        private readonly IConfigurationRoot configuration;

        public RoleDomainServices(IConfigurationRoot configuration, IRoleRepository repository)
        {
            this.repository = repository;
            this.configuration = configuration;
        }

        public ServiceResult<Role> GetRoleById(int RoleId)
        {
            var getRole = this.repository.GetRoleById(RoleId);

            return new ServiceResult<Role>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getRole
            };
        }

        public ServiceResult<IEnumerable<Role>> GetRoles(int pageNumber, int pageSize)
        {
            var getRoles = this.repository.GetRoles(pageNumber, pageSize);
            return new ServiceResult<IEnumerable<Role>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getRoles
            };
        }

        public ServiceResult<Role> Insert(Role role)
        {
            Role emailExist = this.repository.GetRoleByName(role.Name);

            if (emailExist == null)
            {
                var roleInserted = this.repository.Insert(role);
                return new ServiceResult<Role>
                {
                    Success = true,
                    Result = roleInserted
                };
            }

            return new ServiceResult<Role>
            {
                Success = false,
                Errors = new string[] { MessageError.NameRoleExists }
            };
        }

        public ServiceResult<Role> Update(Role role)
        {
            Role emailExist = this.repository.GetRoleByNameWithoutId(role.RoleId, role.Name);

            if (emailExist == null)
            {
                var updated = this.repository.Update(role);
                return new ServiceResult<Role>
                {
                    Success = updated,
                    Errors = (updated) ? new string[] { string.Empty } : new string[] { MessageError.RoleUpdate }
                };
            }

            return new ServiceResult<Role>
            {
                Success = false,
                Errors = new string[] { MessageError.EmailExists }
            };
        }
    }
}
