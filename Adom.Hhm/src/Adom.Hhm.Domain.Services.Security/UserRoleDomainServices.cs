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
    public class UserRoleDomainServices : IUserRoleDomainServices
    {
        private readonly IUserRoleRepository repository;
        private readonly IRoleRepository repositoryRole;
        private readonly IConfigurationRoot configuration;

        public UserRoleDomainServices(IConfigurationRoot configuration, IUserRoleRepository repository, IRoleRepository repositoryRole)
        {
            this.repository = repository;
            this.configuration = configuration;
            this.repositoryRole = repositoryRole;
        }

        public ServiceResult<IEnumerable<UserRole>> GetRolesByUserId(int userId)
        {
            List<UserRole> userRolesReturn = null;
            var userRoles = this.repository.GetRolesByUserId(userId);
            var roles = this.repositoryRole.GetRoles();

            if (userRoles == null)
            {
                userRolesReturn = new List<UserRole>();
            }
            else
            {
                userRolesReturn = new List<UserRole>(userRoles.ToList());
            }

            foreach (var role in roles)
            {
                var existRole = userRoles.Where(p => p.RoleId == role.RoleId).FirstOrDefault();

                if (existRole == null) {
                    UserRole userRole = new UserRole();
                    userRole.HasRole = false;
                    userRole.RoleId = role.RoleId;
                    userRole.UserId = userId;
                    userRole.RoleName = role.Name;
                    userRolesReturn.Add(userRole);
               }
            }

            return new ServiceResult<IEnumerable<UserRole>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = userRolesReturn
            };
        }

        public ServiceResult<bool> ManagerUserRole(UserRole userRole)
        {
            bool response = false;
            UserRole findUserRole = this.repository.GeUserRolByUserIdRoleID(userRole.UserId, userRole.RoleId);

            if (userRole.HasRole)
            {
                if (findUserRole == null)
                {
                    response = this.repository.Insert(userRole);
                }
            }
            else
            {
                if (findUserRole != null)
                {
                    response = this.repository.Delete(userRole);
                }
            }

            return new ServiceResult<bool>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = response
            };
        }
    }
}
