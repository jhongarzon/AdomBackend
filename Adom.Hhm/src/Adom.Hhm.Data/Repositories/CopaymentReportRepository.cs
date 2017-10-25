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
            if (!string.IsNullOrEmpty(copaymentReportFilter.InitialDateIni))
            {
                copaymentReport += " Ags.[InitialDate] > CONVERT(DATE, @InitialDateIni, 105) ";
            }
            if (!string.IsNullOrEmpty(copaymentReportFilter.InitialDateEnd))
            {
                copaymentReport += " AND Ags.[InitialDate] < CONVERT(DATE, @InitialDateEnd, 105) ";
            }
            if (!string.IsNullOrEmpty(copaymentReportFilter.FinalDateIni))
            {
                copaymentReport += " AND Ags.[FinalDate] > CONVERT(DATE, @FinalDateIni, 105) ";
            }
            if (!string.IsNullOrEmpty(copaymentReportFilter.FinalDateEnd))
            {
                copaymentReport += " AND Ags.[FinalDate] < CONVERT(DATE, @FinalDateEnd, 105) ";
            }
            if (!string.IsNullOrEmpty(copaymentReportFilter.FinalDateEnd))
            {
                copaymentReport += " AND Ags.[FinalDate] < CONVERT(DATE, @FinalDateEnd, 105) ";
            }
            if (!string.IsNullOrEmpty(copaymentReportFilter.DeliverDateIni))
            {
                copaymentReport += " AND Ags.[RecordDate] > CONVERT(DATE, @DeliverDateIni, 105) ";
            }
            if (!string.IsNullOrEmpty(copaymentReportFilter.DeliverDateEnd))
            {
                copaymentReport += " AND Ags.[RecordDate] < CONVERT(DATE, @DeliverDateEnd, 105) ";
            }

            return _dbConnection.Query<CopaymentReport>(copaymentReport, copaymentReportFilter);
        }
    }
}
