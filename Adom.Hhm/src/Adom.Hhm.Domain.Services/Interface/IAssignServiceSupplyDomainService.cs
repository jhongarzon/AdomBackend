using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Services.Interface
{
    public interface IAssignServiceSupplyDomainService
    {
        ServiceResult<IEnumerable<AssignServiceSupply>> GetAssignServiceSupplies(int pageNumber, int pageSize);
        ServiceResult<IEnumerable<AssignServiceSupply>> GetAssignServiceSupplies();
        ServiceResult<AssignServiceSupply> GetAssignServiceSupplyById(int assignServiceSupplyId);
        ServiceResult<AssignServiceSupply> GetAssignServiceSupplyByAssignServiceId(int assignServiceId);
        ServiceResult<AssignServiceSupply> Insert(AssignServiceSupply assignServiceSupply);
        ServiceResult<AssignServiceSupply> Update(AssignServiceSupply assignServiceSupply);
    }
}
