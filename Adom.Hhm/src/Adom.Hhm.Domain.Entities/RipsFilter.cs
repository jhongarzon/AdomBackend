namespace Adom.Hhm.Domain.Entities
{
    public class RipsFilter
    {
        public int EntityId { get; set; }
        public int EntityPlanId { get; set; }
        public int ServiceTypeId { get; set; }
        public string InitialDateIni { get; set; }
        public string InitialDateEnd { get; set; }
        public string FinalDateIni { get; set; }
        public string FinalDateEnd { get; set; }
        public int Copayment { get; set; }
        public int NetValue { get; set; }
        public string InvoiceDate { get; set; }
        public string InvoiceNumber { get; set; }

    }
}
