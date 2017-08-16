namespace Adom.Hhm.Domain.Entities.Reports
{
    public class CopaymentReportFilter
    {
        public int ProfessionalId { get; set; }
        public string InitialDate { get; set; }
        public string FinalDate { get; set; }
        public string DeliverDate { get; set; }
    }
}
