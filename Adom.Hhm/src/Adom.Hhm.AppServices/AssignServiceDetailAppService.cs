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
            return this.service.GetAssignServiceDetailById(assignServiceDetailId);
        }

        public ServiceResult<AssignServiceDetail> GetAssignServiceDetailByAssignServiceId(int assignServiceId)
        {
            return this.service.GetAssignServiceDetailByAssignServiceId(assignServiceId);
        }

        public ServiceResult<IEnumerable<AssignServiceDetail>> GetAssignServiceDetails(int pageNumber, int pageSize)
        {
            return this.service.GetAssignServiceDetails(pageNumber, pageSize);
        }

        public ServiceResult<IEnumerable<AssignServiceDetail>> GetAssignServiceDetails()
        {
            return this.service.GetAssignServiceDetails();
        }

        public ServiceResult<AssignServiceDetail> Update(AssignServiceDetail assignServiceDetail)
        {
            return this.service.Update(assignServiceDetail);
        }
    }
}
