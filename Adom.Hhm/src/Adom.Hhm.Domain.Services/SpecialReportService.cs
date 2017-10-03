using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adom.Hhm.Domain.Entities.Reports;
using Adom.Hhm.Domain.Entities.Security;
using Adom.Hhm.Domain.Repositories;
using Adom.Hhm.Domain.Services.Interface;

namespace Adom.Hhm.Domain.Services
{
    public class SpecialReportService : ISpecialReportService
    {
        private readonly ISpecialReportRepository _specialReportRepository;
        public SpecialReportService(ISpecialReportRepository specialReportRepository)
        {
            _specialReportRepository = specialReportRepository;
        }
        public ServiceResult<IEnumerable<SpecialSummaryReport>> GetSpecialSummaryReport(SpecialReportFilter specialReportFilter)
        {
            var result = _specialReportRepository.GetSpecialSummaryReport(specialReportFilter);
            return new ServiceResult<IEnumerable<SpecialSummaryReport>>
            {
                Result = result,
                Errors = new[] { string.Empty },
                Success = true
            };
        }

        public ServiceResult<IEnumerable<SpecialDetailedReport>> GetSpecialDetailedReport(SpecialReportFilter specialReportFilter)
        {
            var result = _specialReportRepository.GetSpecialDetailedReport(specialReportFilter);
            return new ServiceResult<IEnumerable<SpecialDetailedReport>>
            {
                Result = result,
                Errors = new[] { string.Empty },
                Success = true
            };
        }
    }
}
