using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Entities.Reports
{
    public class PaymentReportFilter
    {
        public int EntityId { get; set; }
        public int PlanEntityId { get; set; }
        public int ServiceId { get; set; }
        public string InitialDateIni { get; set; }
        public string InitialDateEnd { get; set; }
    }
}
