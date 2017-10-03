using System.Collections.Generic;
using Adom.Hhm.Domain.Entities.Reports;

namespace Adom.Hhm.Domain.Repositories
{
    public interface ISpecialReportRepository
    {
        IEnumerable<SpecialSummaryReport> GetSpecialSummaryReport(SpecialReportFilter specialReportFilter);
        IEnumerable<SpecialDetailedReport> GetSpecialDetailedReport(SpecialReportFilter specialReportFilter);
    }
}
