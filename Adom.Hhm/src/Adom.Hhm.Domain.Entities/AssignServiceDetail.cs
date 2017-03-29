using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Entities
{
    public class AssignServiceDetail
    {
        public int AssignServiceDetailId { get; set; }
        public int AssignServiceId { get; set; }
        public int ProfessionalId { get; set; }
        public string ProfessionalName { get; set; }
        public string DateVisit { get; set; }
        public int Consecutive { get; set; }
        public string Observation { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int TotalRows { get; set; }
    }
}
