using Adom.Hhm.Data.Repositories;
using Adom.Hhm.Domain.Secutiry.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adom.Hhm.Domain.Entities.Security;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.Data;
using Adom.Hhm.Data.Querys;
using Dapper;

namespace Adom.Hhm.Data.Repositories
{
    public class RoleActionResourceRepository : IRoleActionResourceRepository
    {
        private readonly IDbConnection connection;

        public RoleActionResourceRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public IEnumerable<RoleActionResource> GetActionsResources()
        {
            return this.connection.Query<RoleActionResource>(RoleActionResourceQuerys.GetActionsResources);
        }

        public RoleActionResource GeRoleActionResource(int roleId, int actionResourceId)
        {
            return this.connection.Query<RoleActionResource>(RoleActionResourceQuerys.GeRoleActionResource, new { ActionResourceId = actionResourceId, RoleId = roleId }).FirstOrDefault();
        }

        public IEnumerable<RoleActionResource> GeRoleActionsResourcesByRoleId(int roleId)
        {
            return this.connection.Query<RoleActionResource>(RoleActionResourceQuerys.GeRoleActionResourceByRoleId, new { RoleId = roleId });
        }

        public bool Insert(RoleActionResource roleActionResource)
        {
            var affectedRows = connection.Execute(RoleActionResourceQuerys.Insert, roleActionResource);
            return affectedRows > 0;
        }

        public bool Delete(RoleActionResource roleActionResource)
        {
            var affectedRows = connection.Execute(RoleActionResourceQuerys.Delete, roleActionResource);
            return affectedRows > 0;
        }
    }
}
