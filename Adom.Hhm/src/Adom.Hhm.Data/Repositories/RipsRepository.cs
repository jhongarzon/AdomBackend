using System.Collections.Generic;
using System.Data;
using System.Text;
using Adom.Hhm.Data.Querys;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Repositories;
using Dapper;
using System.Linq;

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
                whereClause.Append("AND CONVERT(DATETIME,ags.InitialDate) > CONVERT(DATETIME,@InitialDate, 105) ");
            }
            if (!string.IsNullOrEmpty(ripsFilter.FinalDate))
            {
                whereClause.Append("AND CONVERT(DATETIME,ags.FinalDate) < CONVERT(DATETIME,@FinalDate, 105) ");
            }
            var finalQuery = string.Format("{0} {1}", RipsQuerys.GetServiceRips, whereClause);
            return _dbConnection.Query<Rips>(finalQuery, ripsFilter);
        }

        public IEnumerable<AssignServiceSupply> GetServiceSupplies(int assignServiceId)
        {
            return _dbConnection.Query<AssignServiceSupply>(RipsQuerys.GetServiceSupplies, new { assignServiceId });
        }

        public IEnumerable<AssignServiceDetail> GetServiceDetail(int assignServiceId)
        {
            return _dbConnection.Query<AssignServiceDetail>(RipsQuerys.GetServiceDetail, new { assignServiceId });
        }

        public int InsertRipsControl(string invoiceNumber)
        {
            return _dbConnection.Query<int>(RipsQuerys.InsertGeneratedRips, new { @InvoiceNumber = invoiceNumber }).Single();
        }

        public void UpdateServiceInvoice(int assignServiceId, string invoiceNumber)
        {
            _dbConnection.Execute(RipsQuerys.UpdateServiceInvoice, new
            {
                @AssignServiceId = assignServiceId,
                @InvoiceNumber = invoiceNumber
            });
        }
    }
}
