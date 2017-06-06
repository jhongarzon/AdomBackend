namespace Adom.Hhm.Domain.Entities
{
    public class RipsFilter
    {
        public int EntityId { get; set; }
        public int EntityPlanId { get; set; }
        public int ServiceTypeId { get; set; }
        public string InitialDate { get; set; }
        public string FinalDate { get; set; }
        public int Copayment { get; set; }
        public int NetValue { get; set; }
        public string InvoiceDate { get; set; }
        public string InvoiceNumber { get; set; }

    }
}
