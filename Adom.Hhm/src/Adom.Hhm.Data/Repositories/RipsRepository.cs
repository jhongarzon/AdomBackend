using System.Collections.Generic;
using System.Data;
using System.Text;
using Adom.Hhm.Data.Querys;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Repositories;
using Dapper;

namespace Adom.Hhm.Data.Repositories
{
    public class RipsRepository : IRipsRepository
    {
        private readonly IDbConnection _dbConnection;

        public RipsRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<Rips> GetServiceRips(RipsFilter ripsFilter)
        {
            var whereClause = new StringBuilder("WHERE 1 = 1 ");
            if (ripsFilter.EntityId > 0)
            {
                whereClause.Append("AND ent.EntityId = @EntityId ");
            }
            if (ripsFilter.EntityPlanId > 0)
            {
                whereClause.Append("AND pe.EntityId = @EntityPlanId ");
            }
            if (ripsFilter.ServiceTypeId > 0)
            {
                whereClause.Append("AND ser.ServiceTypeId = @ServiceTypeId ");
            }
            if (!string.IsNullOrEmpty(ripsFilter.InitialDate))
            {
                whereClause.Append("AND ags.InitialDate = @InitialDate ");
            }
            if (!string.IsNullOrEmpty(ripsFilter.FinalDate))
            {
                whereClause.Append("AND ags.FinalDate = @FinalDate ");
            }
            var finalQuery = string.Format("{0} {1}", RipsQuerys.GetServiceRips, whereClause);
            return _dbConnection.Query<Rips>(finalQuery, ripsFilter);
        }

        public IEnumerable<AssignServiceSupply> GetServiceSupplies(int assignServiceId)
        {
            return _dbConnection.Query<AssignServiceSupply>(RipsQuerys.GetServiceSupplies, new { assignServiceId });
        }
    }
}
