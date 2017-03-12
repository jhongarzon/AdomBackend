using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.AppServices.Interfaces
{
    public interface ISupplyAppService
    {
        ServiceResult<IEnumerable<Supply>> GetSupplies(int pageNumber, int pageSize);
        ServiceResult<IEnumerable<Supply>> GetSupplies();
        ServiceResult<Supply> GetSupplyById(int SupplyId);
        ServiceResult<Supply> Insert(Supply Supply);
        ServiceResult<Supply> Update(Supply Supply);
    }
}
