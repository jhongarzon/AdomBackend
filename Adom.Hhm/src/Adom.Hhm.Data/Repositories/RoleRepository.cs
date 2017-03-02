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
    public class RoleRepository : IRoleRepository
    {
        private readonly IDbConnection connection;

        public RoleRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public Role GetRoleByName(string name)
        {
            return connection.Query<Role>(RoleQuerys.GetByName, new { Name = name }).FirstOrDefault();
        }

        public Role GetRoleByNameWithoutId(int RoleId, string name)
        {
            return connection.Query<Role>(RoleQuerys.GetByNameWithoutId, new { Name = name, RoleId = RoleId }).FirstOrDefault();
        }

        public Role GetRoleById(int RoleId)
        {
            return connection.Query<Role>(RoleQuerys.GetById, new { RoleId = RoleId }).FirstOrDefault();
        }

        public IEnumerable<Role> GetRoles(int pageNumber, int pageSize)
        {
            return connection.Query<Role>(RoleQuerys.GetAll, new { PageNumber = pageNumber, PageSize = pageSize });
        }

        public Role Insert(Role role)
        {
            var id = connection.Query<int>(RoleQuerys.Insert, role).Single();
            role.RoleId = id;
            role.State = true;
            return role;
        }

        public bool Update(Role Role)
        {
            var affectedRows = connection.Execute(RoleQuerys.Update, Role);
            return affectedRows > 0;
        }

        public IEnumerable<Role> GetRoles()
        {
            return connection.Query<Role>(RoleQuerys.GetAllWithoutPagination);
        }
    }
}
