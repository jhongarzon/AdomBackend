using System.Collections.Generic;
using System.Data;
using Adom.Hhm.Data.Querys;
using Adom.Hhm.Domain.Entities.Reports;
using Adom.Hhm.Domain.Repositories;
using Dapper;

namespace Adom.Hhm.Data.Repositories
{
    public class PaymentReportRepository : IPaymentReportRepository
    {
        private readonly IDbConnection _dbConnection;
        public PaymentReportRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public IEnumerable<PaymentReport> GetPaymentReport()
        {
            return _dbConnection.Query<PaymentReport>(PaymentReportQuerys.GetPaymentReport);
        }
    }
}
