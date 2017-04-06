using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Entities
{
    public class PlanEntity
    {
        public int PlanEntityId { get; set; }
        public int EntityId { get; set; }
        public string EntityName { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
    }
}
