﻿using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.AppServices.Interfaces
{
    public interface IAssignServiceSupplyAppService
    {
        ServiceResult<IEnumerable<AssignServiceSupply>> GetAssignServiceSupplies(int pageNumber, int pageSize);
        ServiceResult<IEnumerable<AssignServiceSupply>> GetAssignServiceSupplies();
        ServiceResult<AssignServiceSupply> GetAssignServiceSupplyById(int assignServiceSupplyId);
        ServiceResult<IEnumerable<AssignServiceSupply>> GetAssignServiceSupplyByAssignServiceId(int assignServiceId);
        ServiceResult<AssignServiceSupply> Insert(AssignServiceSupply assignServiceSupply);
        ServiceResult<AssignServiceSupply> Update(AssignServiceSupply assignServiceSupply);
        ServiceResult<bool> Delete(int assignServiceSupplyId);
    }
}
