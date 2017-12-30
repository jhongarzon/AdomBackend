namespace Adom.Hhm.Domain.Entities.Reports
{
    public class ProfessionalCopaymentReport
    {
        public int ProfessionalId { get; set; }
        public string ProfessionalName { get; set; }
        public decimal ReceivedAmount { get; set; }
    }
}
