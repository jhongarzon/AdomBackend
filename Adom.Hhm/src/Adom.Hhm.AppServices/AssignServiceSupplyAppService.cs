using System.Collections.Generic;
using Adom.Hhm.Domain.Entities.Security;
using Adom.Hhm.Domain.Services.Interface;
using Adom.Hhm.AppServices.Interfaces;
using Adom.Hhm.Domain.Entities;

namespace Adom.Hhm.AppServices
{
    public class AssignServiceSupplyAppService : IAssignServiceSupplyAppService
    {
        private readonly IAssignServiceSupplyDomainService service;

        public AssignServiceSupplyAppService(IAssignServiceSupplyDomainService service)
        {
            this.service = service;
        }

        public ServiceResult<AssignServiceSupply> GetAssignServiceSupplyById(int AssignServiceSupplyId)
        {
            return this.service.GetAssignServiceSupplyById(AssignServiceSupplyId);
        }

        public ServiceResult<AssignServiceSupply> GetAssignServiceSupplyByAssignServiceId(int assignServiceId)
        {
            return this.service.GetAssignServiceSupplyByAssignServiceId(assignServiceId);
        }

        public ServiceResult<IEnumerable<AssignServiceSupply>> GetAssignServiceSupplies(int pageNumber, int pageSize)
        {
            return this.service.GetAssignServiceSupplies(pageNumber, pageSize);
        }

        public ServiceResult<IEnumerable<AssignServiceSupply>> GetAssignServiceSupplies()
        {
            return this.service.GetAssignServiceSupplies();
        }

        public ServiceResult<AssignServiceSupply> Insert(AssignServiceSupply assignServiceSupply)
        {
            return this.service.Insert(assignServiceSupply);
        }

        public ServiceResult<AssignServiceSupply> Update(AssignServiceSupply AssignServiceSupply)
        {
            return this.service.Update(AssignServiceSupply);
        }

        public ServiceResult<bool> Delete(int AssignServiceSupplyId)
        {
            return this.service.Delete(AssignServiceSupplyId);
        }
    }
}
