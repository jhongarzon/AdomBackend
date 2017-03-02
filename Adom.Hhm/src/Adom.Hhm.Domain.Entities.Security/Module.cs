using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Entities.Security
{
    public class Module
    {
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
    }
}
