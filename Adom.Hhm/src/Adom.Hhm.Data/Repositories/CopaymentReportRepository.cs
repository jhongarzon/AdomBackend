using System.Collections.Generic;
using System.Data;
using Adom.Hhm.Data.Querys;
using Adom.Hhm.Domain.Entities.Reports;
using Adom.Hhm.Domain.Repositories;
using Dapper;

namespace Adom.Hhm.Data.Repositories
{
    public class CopaymentReportRepository : ICopaymentReportRepository
    {
        private readonly IDbConnection _dbConnection;
        public CopaymentReportRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<CopaymentReport> GetCopaymentReport(CopaymentReportFilter copaymentReportFilter)
        {
            var copaymentReport = CopaymentReportQuerys.GetCopaymentReport;
            if (copaymentReportFilter.ProfessionalId > 0)
            {
                copaymentReport += "AND Ags.[ProfessionalId] = @ProfessionalId ";
            }
            return _dbConnection.Query<CopaymentReport>(copaymentReport, copaymentReportFilter);
        }
    }
}
