using System;
using System.Collections.Generic;
using Adom.Hhm.Domain.Entities.Reports;
using Adom.Hhm.Domain.Entities.Security;
using Adom.Hhm.Domain.Repositories;
using Adom.Hhm.Domain.Services.Interface;

namespace Adom.Hhm.Domain.Services
{
    public class CopaymentReportService : ICopaymentReportService
    {
        private readonly ICopaymentReportRepository _copaymentReportRepository;
        public CopaymentReportService(ICopaymentReportRepository copaymentReportRepository)
        {
            _copaymentReportRepository = copaymentReportRepository;
        }
        public ServiceResult<IEnumerable<CopaymentReport>> GetCopaymentReport()
        {
            var result = _copaymentReportRepository.GetCopaymentReport();
            return new ServiceResult<IEnumerable<CopaymentReport>>
            {
                Success = true,
                Errors = new[] { string.Empty },
                Result = result
            };
        }
    }
}
