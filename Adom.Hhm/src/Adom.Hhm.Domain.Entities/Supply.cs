using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Entities
{
    public class Supply
    {
        public int SupplyId { get; set; }
        public string Presentation { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
