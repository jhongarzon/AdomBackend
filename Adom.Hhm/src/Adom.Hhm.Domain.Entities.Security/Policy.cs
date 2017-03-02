using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Entities.Security
{
    public class Policy
    {
        public string ResourceId { get; set; }
        public string ResourceName { get; set; }
        public string ModuleId { get; set; }
        public string ModuleName { get; set; }
        public string ActionName { get; set; }
        public string Route { get; set; }
        public string RouteFrontEnd { get; set; }

    }
}