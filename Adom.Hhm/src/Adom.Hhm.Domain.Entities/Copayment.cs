namespace Adom.Hhm.Domain.Entities
{
    public class Copayment
    {
        public int AssignServiceId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientDocument { get; set; }
        public string ContractNumber { get; set; }
        public int EntityId { get; set; }
        public string EntityName { get; set; }
        public string AuthorizationNumber { get; set; }
        public string ApplicantName { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int Quantity { get; set; }
        public int QuantityCompleted { get; set; }
        public string InitialDate { get; set; }
        public string FinalDate { get; set; }
        public int ProfessionalId { get; set; }
        public string ProfessionalName { get; set; }
        public decimal CoPaymentAmount { get; set; }
        public int CoPaymentFrecuencyId { get; set; }
        public string CoPaymentFrecuencyName { get; set; }
        public int StateId { get; set; }
        public string CopaymentStatus { get; set; }
        public string StateName { get; set; }
        public int TotalCopaymentReported { get; set; }
        public int OtherValuesReported { get; set; }
        public int ValueToPayToProfessional { get; set; }
        public int TotalRows { get; set; }
        public int TotalCopaymentReceived { get; set; }
        public int OtherValuesReceived { get; set; }
        public int Discounts { get; set; }
        public int DeliveredCopayments { get; set; }
    }
}
