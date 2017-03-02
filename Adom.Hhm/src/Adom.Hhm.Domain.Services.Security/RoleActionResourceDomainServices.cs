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
    public class RoleActionResourceDomainServices : IRoleActionResourceDomainServices
    {
        private readonly IRoleActionResourceRepository repository;
        private readonly IConfigurationRoot configuration;

        public RoleActionResourceDomainServices(IConfigurationRoot configuration, IRoleActionResourceRepository repository)
        {
            this.repository = repository;
            this.configuration = configuration;
        }

        public ServiceResult<IEnumerable<RoleActionResource>> GetRoleActionsResourcesByRole(int roleId)
        {
            List<RoleActionResource> roleActionsResourcesReturn = null;
            var roleActionsResources = this.repository.GeRoleActionsResourcesByRoleId(roleId);
            var actionsResources = this.repository.GetActionsResources();

            if (roleActionsResources == null || roleActionsResources.Count() == 0)
            {
                roleActionsResourcesReturn = new List<RoleActionResource>();
            }
            else
            {
                roleActionsResourcesReturn = new List<RoleActionResource>(roleActionsResources.ToList());
            }

            foreach (var actionResource in actionsResources)
            {
                var existActionsResources = roleActionsResources.Where(p => p.ActionResourceId == actionResource.ActionResourceId).FirstOrDefault();

                if (existActionsResources == null)
                {
                    actionResource.HasRole = false;
                    actionResource.RoleId = roleId;
                    roleActionsResourcesReturn.Add(actionResource);
                }
            }

            return new ServiceResult<IEnumerable<RoleActionResource>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = roleActionsResourcesReturn
            };
        }

        public ServiceResult<bool> ManagerRoleActionsResources(RoleActionResource roleActionResource)
        {
            bool response = false;
            RoleActionResource findRoleActionResource = this.repository.GeRoleActionResource(roleActionResource.RoleId, roleActionResource.ActionResourceId);

            if (roleActionResource.HasRole)
            {
                if (findRoleActionResource == null)
                {
                    response = this.repository.Insert(roleActionResource);
                }
            }
            else
            {
                if (roleActionResource != null)
                {
                    response = this.repository.Delete(roleActionResource);
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
