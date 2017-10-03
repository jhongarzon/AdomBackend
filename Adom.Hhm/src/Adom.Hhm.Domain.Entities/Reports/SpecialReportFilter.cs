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
        public string InitialDateIni { get; set; }
        public string RequestDateIni { get; set; }
        public string VisitDateIni { get; set; }
        public string InitialDateEnd { get; set; }
        public string RequestDateEnd { get; set; }
        public string VisitDateEnd { get; set; }
        public int ReportType { get; set; }
    }
}
