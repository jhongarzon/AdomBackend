using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Services.Interface
{
    public interface IParameterDomainService
    {
        ServiceResult<IEnumerable<Parameter>> GetDataParametricTable(string parametricTable);
    }
}
