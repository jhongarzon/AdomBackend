﻿using System.Collections.Generic;
using Adom.Hhm.Domain.Entities.Reports;
using Adom.Hhm.Domain.Entities.Security;

namespace Adom.Hhm.Domain.Services.Interface
{
    public interface IHomeDomainService
    {
        ServiceResult<HomeReport> GetHomeReport();
    }
}
