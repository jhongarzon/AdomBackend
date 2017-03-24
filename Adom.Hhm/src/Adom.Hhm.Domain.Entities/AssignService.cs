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
        public string AuthorizationNumber { get; set; }
        public DateTime Validity { get; set; }
        public string ApplicantName { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int Quantity { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
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
    }
}
