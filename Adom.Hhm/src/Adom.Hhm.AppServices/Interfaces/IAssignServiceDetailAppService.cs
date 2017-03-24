using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.AppServices.Interfaces
{
    public interface IAssignServiceDetailAppService
    {
        ServiceResult<IEnumerable<AssignServiceDetail>> GetAssignServiceDetails(int pageNumber, int pageSize);
        ServiceResult<IEnumerable<AssignServiceDetail>> GetAssignServiceDetails();
        ServiceResult<AssignServiceDetail> GetAssignServiceDetailById(int assignServiceDetailId);
        ServiceResult<AssignServiceDetail> GetAssignServiceDetailByAssignServiceId(int assignServiceId);
        ServiceResult<AssignServiceDetail> Update(AssignServiceDetail assignServiceDetail);
    }
}
