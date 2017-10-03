using System.Collections.Generic;
using Adom.Hhm.Domain.Entities.Security;
using Adom.Hhm.Domain.Services.Interface;
using Adom.Hhm.AppServices.Interfaces;
using Adom.Hhm.Domain.Entities;

namespace Adom.Hhm.AppServices
{
    public class AssignServiceDetailAppService : IAssignServiceDetailAppService
    {
        private readonly IAssignServiceDetailDomainService service;

        public AssignServiceDetailAppService(IAssignServiceDetailDomainService service)
        {
            this.service = service;
        }

        public ServiceResult<AssignServiceDetail> GetAssignServiceDetailById(int assignServiceDetailId)
        {
            return service.GetAssignServiceDetailById(assignServiceDetailId);
        }

        public ServiceResult<IEnumerable<AssignServiceDetail>> GetAssignServiceDetailByAssignServiceId(int assignServiceId)
        {
            return service.GetAssignServiceDetailByAssignServiceId(assignServiceId);
        }

        public ServiceResult<IEnumerable<AssignServiceDetail>> GetAssignServiceDetails(int pageNumber, int pageSize)
        {
            return service.GetAssignServiceDetails(pageNumber, pageSize);
        }

        public ServiceResult<IEnumerable<AssignServiceDetail>> GetAssignServiceDetails()
        {
            return service.GetAssignServiceDetails();
        }

        public ServiceResult<AssignServiceDetail> Update(AssignServiceDetail assignServiceDetail)
        {
            return service.Update(assignServiceDetail);
        }

        public ServiceResult<IEnumerable<QualityQuestion>> GetQuestions(int serviceId)
        {
            return service.GetQuestions(serviceId);
        }

        public ServiceResult<string> SaveAnswers(int assignServiceDetailId, int qualityCallUser, IEnumerable<QualityQuestion> answers)
        {
            return service.SaveAnswers(assignServiceDetailId, qualityCallUser, answers);
        }
    }
}
