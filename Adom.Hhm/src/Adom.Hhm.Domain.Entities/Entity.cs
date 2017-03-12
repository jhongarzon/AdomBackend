using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Entities
{
    public class Entity
    {
        public int EntityId { get; set; }
        public string Nit { get; set; }
        public string Code { get; set; }
        public string BusinessName { get; set; }
        public string Name { get; set; }
    }
}
