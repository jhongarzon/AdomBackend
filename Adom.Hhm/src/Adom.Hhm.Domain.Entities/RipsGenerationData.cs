using System.Collections.Generic;

namespace Adom.Hhm.Domain.Entities
{
    public class RipsGenerationData
    {
        public RipsFilter RipsFilter { get; set; }
        public IEnumerable<Rips> Rips { get; set; }
    }
}
