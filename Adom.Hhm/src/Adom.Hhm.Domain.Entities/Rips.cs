namespace Adom.Hhm.Domain.Entities
{
    public class Rips
    {
        public int AssignServiceId { get; set; }
        public int PatientId { get; set; }
        public string DocumentTypeName { get; set; }
        public string DocumentTypeAbbreviation { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string SecondSurname { get; set; }
        public string PatientName { get; set; }
        public string PatientDocument { get; set; }
        public string RipsUserType { get; set; }
        public int Age { get; set; }
        public int AgeUnit { get; set; }
        public string Gender { get; set; }
        public long ProviderCode { get; set; }
        public string BusinessName { get; set; }
        public string AdomIdentificationType { get; set; }
        public string AdomIdentificationNumber { get; set; }
        public string DepartmentCode { get; set; }
        public string CityCode { get; set; }
        public string ResidenceArea { get; set; }
        public string ContractNumber { get; set; }
        public int EntityId { get; set; }
        public string EntityCode { get; set; }
        public string EntityName { get; set; }
        public string AuthorizationNumber { get; set; }
        public string ApplicantName { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Cups { get; set; }
        public int Rate { get; set; }
        public int Quantity { get; set; }
        public int External { get; set; }
        public int Consultation { get; set; }
        public int Cie10 { get; set; }
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
        public int EntityPlanId { get; set; }
        public string PlanEntityName { get; set; }

    }
}
