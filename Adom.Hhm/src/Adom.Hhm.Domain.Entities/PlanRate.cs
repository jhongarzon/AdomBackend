﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Entities
{
    public class PlanRate
    {
        public int PlanRateId { get; set; }
        public int PlanEntityId { get; set; }
        public string ServiceName { get; set; }
        public int ServiceId { get; set; }
        public int Rate { get; set; }
        public string Validity { get; set; }
    }
}
