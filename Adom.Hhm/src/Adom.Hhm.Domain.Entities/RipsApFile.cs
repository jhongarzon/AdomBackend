namespace Adom.Hhm.Domain.Entities
{
    public class RipsApFile
    {
        public string InvoiceNumber { get; set; }
        public long ProviderCode { get; set; }
        public string DocumentTypeName { get; set; }
        public string PatientDocument { get; set; }
        public string FinalDate { get; set; }
        public string AuthorizationNumber { get; set; }
        public string Cups { get; set; }
        public string RealizationScope { get; set; }
        public string ProcedurePurpose { get; set; }
        public string AttendandPerson { get; set; }
        public string Cie10 { get; set; }
        public string DescCie10 { get; set; }
        public string Complication { get; set; }
        public string  PerformWay { get; set; }
        public int Rate { get; set; }
    }
}
