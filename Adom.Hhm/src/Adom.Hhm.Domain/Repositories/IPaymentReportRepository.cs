﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adom.Hhm.Domain.Entities.Reports;

namespace Adom.Hhm.Domain.Repositories
{
    public interface IPaymentReportRepository
    {
        IEnumerable<PaymentReport> GetPaymentReport(PaymentReportFilter paymentReportFilter);
    }
}
