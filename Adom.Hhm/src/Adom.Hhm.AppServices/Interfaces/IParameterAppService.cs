using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.AppServices.Interfaces
{
    public interface IParameterAppService
    {
        ServiceResult<IEnumerable<Parameter>> GetDataParametricTable(string parametricTable);
    }
}
