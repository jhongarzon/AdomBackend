using Adom.Hhm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Repositories
{
    public interface IAssignServiceDetailRepository
    {
        IEnumerable<AssignServiceDetail> GetAssignServiceDetails(int pageNumber, int pageSize);
        IEnumerable<AssignServiceDetail> GetAssignServiceDetails();
        AssignServiceDetail GetAssignServiceDetailById(int assignServiceDetailId);
        AssignServiceDetail GetAssignServiceDetailByAssignServiceId(int assignServiceId);
        AssignServiceDetail Update(AssignServiceDetail assignServiceDetail);
    }
}
