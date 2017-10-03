namespace Adom.Hhm.Domain.Entities.Reports
{
    public class CopaymentReportFilter
    {
        public int ProfessionalId { get; set; }
        public string InitialDateIni { get; set; }
        public string FinalDateIni { get; set; }
        public string DeliverDateIni { get; set; }
        public string InitialDateEnd { get; set; }
        public string FinalDateEnd { get; set; }
        public string DeliverDateEnd { get; set; }
    }
}
