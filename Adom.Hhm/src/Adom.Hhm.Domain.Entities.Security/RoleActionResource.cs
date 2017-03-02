using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Entities.Security
{
    public class RoleActionResource
    {
        public bool HasRole { get; set; }
        public int ActionResourceId { get; set; }
        public int RoleId { get; set; }
        public int ActionId { get; set; }
        public string ActionName { get; set; }
        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
    }
}
