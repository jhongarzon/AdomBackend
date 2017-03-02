using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Entities.Security
{
    public class ServiceResult<TResult>
    {
        public bool Success { get; set; }
        public string[] Errors { get; set; }
        public TResult Result { get; set; }
    }
}
