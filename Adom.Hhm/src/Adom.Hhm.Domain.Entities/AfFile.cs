namespace Adom.Hhm.Domain.Entities
{
    public class AfFile
    {
        public long ProviderCode { get; set; }
        public string BusinessName { get; set; }
        public string AdomIdentiticationTypeId { get; set; }
        public string AdomIdentiticationNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public string InvoiceDate { get; set; }
        public string InitialDate { get; set; }
        public string FinalDate { get; set; }
        public int TotalCopaymentReceived { get; set; }
        public string Comission { get; set; }
        public int OtherValuesReceived { get; set; }
        public int NetValue { get; set; }
    }
}
