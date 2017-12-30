namespace Adom.Hhm.Domain.Entities.Reports
{
    public class PatientReportData
    {
        public string PatientDocument { get; set; }
        public string PatientName { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int PatientId { get; set; }
        public int AssignServiceId { get; set; }
        public string Reason { get; set; }
    }
}
