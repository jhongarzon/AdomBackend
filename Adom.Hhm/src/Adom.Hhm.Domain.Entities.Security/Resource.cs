using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Entities.Security
{
    public class Resource
    {
        public int ResouceId { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
    }
}
