using System.Reflection;

namespace Adom.Hhm.Domain.Entities
{
    public class RipsAcFile
    {
        public string InvoiceNumber { get; set; }
        public long ProviderCode { get; set; }
        public string DocumentTypeName { get; set; }
        public string PatientDocument { get; set; }
        public string FinalDate { get; set; }
        public string AuthorizationNumber { get; set; }
        public string Cups { get; set; }
        public int Consultation { get; set; }
        public int External { get; set; }
        public string Cie10 { get; set; }
        public string AddedField1 { get; set; }
        public string AddedField2 { get; set; }
        public string AddedField3 { get; set; }
        public string DiagnosticType { get; set; }
        public int Rate { get; set; }
        public decimal CopaymentPerSession { get; set; }
        public decimal NetValuePerSession { get; set; }
    }
}
