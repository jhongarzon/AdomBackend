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
        public IEnumerable<PaymentReport> GetPaymentReport(PaymentReportFilter paymentReportFilter)
        {
            var paymentReport = PaymentReportQuerys.GetPaymentReport;
            if (!string.IsNullOrEmpty(paymentReportFilter.InitialDateIni))
            {
                paymentReport += " AND Ags.[InitialDate] > CONVERT(DATETIME, @InitialDateIni, 105) ";
            }
            if (!string.IsNullOrEmpty(paymentReportFilter.InitialDateEnd))
            {
                paymentReport += " AND Ags.[InitialDate] < CONVERT(DATETIME, @InitialDateEnd, 105) ";
            }
            if (paymentReportFilter.EntityId > 0)
            {
                paymentReport += "AND Ags.[EntityId] = @EntityId ";
            }
            if (paymentReportFilter.PlanEntityId > 0)
            {
                paymentReport += "AND Ags.[PlanEntityId] = @PlanEntityId ";
            }
            if (paymentReportFilter.ServiceId > 0)
            {
                paymentReport += "AND Ags.[ServiceId] = @ServiceId ";
            }
            paymentReport += "ORDER BY Asd.AssignServiceDetailId DESC";
            return _dbConnection.Query<PaymentReport>(paymentReport, paymentReportFilter);
        }
    }
}
