using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Repositories
{
    public interface ILockDateRepository
    {
        bool UpdateLockDate(string lockDate);
    }
}
