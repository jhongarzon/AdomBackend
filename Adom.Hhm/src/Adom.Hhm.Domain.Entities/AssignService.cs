using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Entities
{
    public class AssignService
    {
        public int AssignServiceId { get; set; }
        public int PatientId { get; set; }
        public string ContractNumber { get; set; }
        public int EntityId { get; set; }
        public string EntityName { get; set; }
        public int PlanEntityId { get; set; }
        public string PlanEntityName { get; set; }
        public string AuthorizationNumber { get; set; }
        public string Cie10 { get; set; }
        public string DescriptionCie10 { get; set; }
        public string Validity { get; set; }
        public string ApplicantName { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int Quantity { get; set; }
        public int QuantityCompleted { get; set; }
        public string InitialDate { get; set; }
        public string FinalDate { get; set; }
        public int ServiceFrecuencyId { get; set; }
        public string ServiceFrecuencyName { get; set; }
        public int ProfessionalId { get; set; }
        public string ProfessionalName { get; set; }
        public decimal CoPaymentAmount { get; set; }
        public int CoPaymentFrecuencyId { get; set; }
        public string CoPaymentFrecuencyName { get; set; }
        public int Consultation { get; set; }
        public int External { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string Observation { get; set; }
        public int TotalRows { get; set; }
        public bool AllowsUpdate { get; set; }
        public string AssignedBy { get; set; }
        public string RecordDate { get; set; }
    }
}
