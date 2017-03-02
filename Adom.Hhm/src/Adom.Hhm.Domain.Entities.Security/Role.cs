using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Entities.Security
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        public int TotalRows { get; set; }
    }
}
