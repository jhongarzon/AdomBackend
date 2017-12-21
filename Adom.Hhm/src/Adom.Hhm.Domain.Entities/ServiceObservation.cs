using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Entities
{
    public class ServiceObservation
    {
        public int AssignServiceObservationId { get; set; }
        public int AssignServiceId { get; set; }
        public string Description { get; set; }
        public string RecordDate { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool AllowDelete { get; set; }
    }
}
