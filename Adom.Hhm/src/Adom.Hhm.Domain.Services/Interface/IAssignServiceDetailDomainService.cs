using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Services.Interface
{
    public interface IAssignServiceDetailDomainService
    {
        ServiceResult<IEnumerable<AssignServiceDetail>> GetAssignServiceDetails(int pageNumber, int pageSize);
        ServiceResult<IEnumerable<AssignServiceDetail>> GetAssignServiceDetails();
        ServiceResult<AssignServiceDetail> GetAssignServiceDetailById(int assignServiceDetailId);
        ServiceResult<IEnumerable<AssignServiceDetail>> GetAssignServiceDetailByAssignServiceId(int assignServiceId);
        ServiceResult<AssignServiceDetail> Update(AssignServiceDetail assignServiceDetail);
        ServiceResult<IEnumerable<QualityQuestion>> GetQuestions(int serviceId);
        ServiceResult<string> SaveAnswers(int assignServiceDetailId, IEnumerable<QualityQuestion> answers);
    }
}
