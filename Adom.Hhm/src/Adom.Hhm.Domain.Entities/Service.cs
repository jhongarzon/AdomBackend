using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Entities
{
    public class Service
    {
        public int ServiceId { get; set; }
        public decimal Value { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int ClassificationId { get; set; }
        public string ClassificationName { get; set; }
        public int ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
        public int HoursToInvest { get; set; }
    }
}
