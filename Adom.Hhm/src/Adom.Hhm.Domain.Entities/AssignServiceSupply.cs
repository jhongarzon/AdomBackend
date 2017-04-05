using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Entities
{
    public class AssignServiceSupply
    {
        public int AssignServiceSupplyId { get; set; }
        public int AssignServiceId { get; set; }
        public int SupplyId { get; set; }
        public string SupplyName { get; set; }
        public int Quantity { get; set; }
        public int BilledToId { get; set; }
        public string BilledName { get; set; }
        public int TotalRows { get; set; }
    }
}
