namespace Adom.Hhm.Domain.Entities
{
    public class RipsAtFile
    {
        public string InvoiceNumber { get; set; }
        public long ProviderCode { get; set; }
        public string DocumentTypeName { get; set; }
        public string PatientDocument { get; set; }
        public string AuthorizationNumber { get; set; }
        public string ServiceType { get; set; }
        public string SupplyCode { get; set; }
        public string SupplyName { get; set; }
        public int SupplyQuantity { get; set; }
        public int SupplyUnitValue { get; set; }
        public int SupplyTotalValue { get; set; }
    }
}
