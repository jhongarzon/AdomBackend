using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Adom.Hhm.Data.Querys;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Repositories;

namespace Adom.Hhm.Data.Repositories
{
    public class ProfessionalAssignedRepository : IProfessionalAssignedRepository
    {
        private readonly IDbConnection _connection;

        public ProfessionalAssignedRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<ProfessionalAssignedServices> GetAssignedServices(int userId, int statusId)
        {
            return _connection.Query<ProfessionalAssignedServices>(ProfessionalAssignedQuerys.GetByUserId, new { UserId = userId, StatusId = statusId });
        }
    }
}
