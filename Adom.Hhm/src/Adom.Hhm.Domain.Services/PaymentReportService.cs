using System;
using System.Collections.Generic;
using Adom.Hhm.Domain.Entities.Reports;
using Adom.Hhm.Domain.Entities.Security;
using Adom.Hhm.Domain.Repositories;
using Adom.Hhm.Domain.Services.Interface;

namespace Adom.Hhm.Domain.Services
{
    public class PaymentReportService:IPaymentReportService
    {
        private readonly IPaymentReportRepository _paymentReportRepository;
        public PaymentReportService(IPaymentReportRepository paymentReportRepository)
        {
            _paymentReportRepository = paymentReportRepository;
        }
        public ServiceResult<IEnumerable<PaymentReport>> GetPaymentReport()
        {
            var result = _paymentReportRepository.GetPaymentReport();
            return new ServiceResult<IEnumerable<PaymentReport>>
            {
                Result = result,
                Errors = new[] { string.Empty },
                Success = true
            };
        }
    }
}
