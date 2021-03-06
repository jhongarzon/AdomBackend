﻿namespace Adom.Hhm.Domain.Entities
{
    public class RipsAfFile
    {
        public long ProviderCode { get; set; }
        public string BusinessName { get; set; }
        public string AdomIdentiticationTypeId { get; set; }
        public string AdomIdentiticationNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public string InvoiceDate { get; set; }
        public string InitialDate { get; set; }
        public string FinalDate { get; set; }
        public string EntityCode { get; set; }
        public string EntityName { get; set; }
        public string ContractNumber { get; set; }
        public string BenefitPlan { get; set; }
        public string PolicyNumber { get; set; }
        public int TotalCopaymentReceived { get; set; }
        public int Comission { get; set; }
        public int OtherValuesReceived { get; set; }
        public int NetValue { get; set; }
    }
}
