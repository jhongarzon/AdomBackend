using System.Collections.Generic;
using Adom.Hhm.Domain.Entities.Reports;
using Adom.Hhm.Domain.Entities.Security;

namespace Adom.Hhm.Domain.Services.Interface
{
    public interface ISpecialReportService
    {
        ServiceResult<IEnumerable<SpecialSummaryReport>> GetSpecialSummaryReport(SpecialReportFilter specialReportFilter);
        ServiceResult<IEnumerable<SpecialDetailedReport>> GetSpecialDetailedReport(SpecialReportFilter specialReportFilter);
    }
}
