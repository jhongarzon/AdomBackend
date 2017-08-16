using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Entities.Reports
{
    public class SpecialReportFilter
    {
        public int EntityId { get; set; }
        public int ServiceId { get; set; }
        public int PatientType { get; set; }
        public string InitialDate { get; set; }
        public string RequestDate { get; set; }
        public string VisitDate { get; set; }
        public int ReportType { get; set; }
    }
}
