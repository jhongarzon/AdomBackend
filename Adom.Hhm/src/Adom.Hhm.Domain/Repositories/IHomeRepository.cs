using System.Collections.Generic;
using Adom.Hhm.Domain.Entities.Reports;

namespace Adom.Hhm.Domain.Repositories
{
    public interface IHomeRepository
    {
        HomeReport GetHomeReport();
    }
}
