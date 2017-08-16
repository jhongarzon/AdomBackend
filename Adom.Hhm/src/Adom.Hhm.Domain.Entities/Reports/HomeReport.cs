using System.Collections.Generic;

namespace Adom.Hhm.Domain.Entities.Reports
{
    public class HomeReport
    {
        public IEnumerable<ServiceChartStatus> NursingStatuses { get; set; }
        public IEnumerable<ServiceChartStatus> TherapyStatuses { get; set; }
        public IEnumerable<PatientReportData> PatientsWithoutProfessional { get; set; }
        public IEnumerable<PatientReportData> IrreglularServices { get; set; }
        public IEnumerable<ProfessionalCopaymentReport> ProfessionalCopayments { get; set; }
    }
}
